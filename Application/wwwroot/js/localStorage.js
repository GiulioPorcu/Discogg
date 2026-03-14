window.discogg ??= {};
window.discogg.localStorage = {
    // Internal fixed salt for PBKDF2 key derivation
    _salt: "local-storage-fixed-salt",

    // Version identifier for future migrations
    _version: 1,

    // Derives a 256-bit AES-GCM key from the key name + device info
    _deriveKeyAsync: async function (keyName) {
        const enc = new TextEncoder();

        const password = keyName + "|" + this._getSoftFingerprint();

        const keyMaterial = await crypto.subtle.importKey(
            "raw",
            enc.encode(password),
            "PBKDF2",
            false,
            ["deriveKey"]
        );

        return crypto.subtle.deriveKey(
            {
                name: "PBKDF2",
                salt: enc.encode(this._salt),
                iterations: 150000,
                hash: "SHA-256"
            },
            keyMaterial,
            { name: "AES-GCM", length: 256 },
            false,
            ["encrypt", "decrypt"]
        );
    },

    /**
     * Generates a stable, non-unique fingerprint based on browser capabilities (resolution, timezone, language, etc.)
     */
    _getSoftFingerprint: async function() {
        return JSON.stringify({
            lang: navigator.language,
            tz: Intl.DateTimeFormat().resolvedOptions().timeZone,
            res: `${screen.width}x${screen.height}`,
            depth: screen.colorDepth,
            cores: navigator.hardwareConcurrency,
            touch: navigator.maxTouchPoints
        });
    },

    // Computes a SHA-256 integrity hash of the ciphertext
    _computeIntegrityAsync: async function (dataBytes) {
        const hash = await crypto.subtle.digest("SHA-256", dataBytes);
        return Array.from(new Uint8Array(hash));
    },

    /**
     * Encrypts a string using AES‑GCM and stores the encrypted payload in localStorage.
     *
     * @param {string} key    The localStorage key under which the encrypted data is stored.
     * @param {string} value  The plaintext string to encrypt and save.
     */
    setEncryptedAsync: async function (key, value) {
        const enc = new TextEncoder();
        const data = enc.encode(value);

        const aesKey = await this._deriveKeyAsync(key);

        const iv = crypto.getRandomValues(new Uint8Array(12));
        const encrypted = await crypto.subtle.encrypt(
            { name: "AES-GCM", iv },
            aesKey,
            data
        );

        const encryptedBytes = new Uint8Array(encrypted);

        // Integrity protection
        const integrity = await this._computeIntegrityAsync(encryptedBytes);

        const stored = {
            v: this._version,
            iv: Array.from(iv),
            data: Array.from(encryptedBytes),
            integrity
        };

        localStorage.setItem(key, JSON.stringify(stored));
    },

    /**
     * Retrieves a decrypted payload from localStorage and decrypts it using AES‑GCM.
     *
     * @param {string} key    The key containing the encrypted JSON payload.
     * @returns {string|null} The decrypted plaintext string or null if not found.
     */
    getDecryptedAsync: async function (key) {
        const stored = JSON.parse(localStorage.getItem(key));
        if (!stored) return null;

        const aesKey = await this._deriveKeyAsync(key);

        const iv = new Uint8Array(stored.iv);
        const data = new Uint8Array(stored.data);

        // Verify integrity
        const integrityCheck = await this._computeIntegrityAsync(data);
        if (JSON.stringify(integrityCheck) !== JSON.stringify(stored.integrity)) {
            console.warn("localStorageInterop: integrity check failed");
            return null;
        }

        const decrypted = await crypto.subtle.decrypt(
            { name: "AES-GCM", iv },
            aesKey,
            data
        );

        return new TextDecoder().decode(decrypted);
    },

    /**
     * Stores a plain string value in localStorage under the specified key.
     *
     * @param {string} key    The key under which the value is stored.
     * @param {string} value  The string value to save.
     */
    setAsync: async function (key, value) {
        localStorage.setItem(key, value);
    },

    /**
     * Retrieves a plain string value from localStorage for the specified key.
     *
     * @param {string} key  The key whose stored value should be returned.
     * @returns {string|null} The stored value, or null if the key does not exist.
     */
    getAsync: async function (key) {
        return localStorage.getItem(key);
    },

    /**
     * Removes the given key from localStorage.
     *
     * @param {string} key  The key that should be removed.
     */
    removeAsync: async function (key) {
        return localStorage.removeItem(key);
    }
};