using Microsoft.JSInterop;

namespace Application.Interop;

/// <summary>
/// Provides access to browser localStorage operations through JavaScript interop.
/// Supports both plain string storage and AES‑GCM encrypted storage.
/// </summary>
public class LocalStorageService(IJSRuntime _jsRuntime)
{
    /// <summary>
    /// Stores a plain string value in localStorage under the specified key.
    /// </summary>
    /// <param name="key">The key under which the value is stored.</param>
    /// <param name="value">The string value to save.</param>
    public ValueTask SetAsync(string key, string value)
    {
        return _jsRuntime.InvokeVoidAsync("localStorageInterop.set", key, value);
    }

    /// <summary>
    /// Retrieves a plain string value from localStorage for the specified key.
    /// </summary>
    /// <param name="key">The key whose stored value should be returned.</param>
    /// <returns>The stored value, or null if the key does not exist.</returns>
    public ValueTask<string?> GetAsync(string key)
    {
        return _jsRuntime.InvokeAsync<string?>("localStorageInterop.get", key);
    }

    /// <summary>
    /// Encrypts a string using AES‑GCM and stores the encrypted payload in localStorage.
    /// </summary>
    /// <param name="key">The key under which the encrypted value is stored.</param>
    /// <param name="value">The plaintext string to encrypt and save.</param>
    public ValueTask SetEncryptedAsync(string key, string value)
    {
        return _jsRuntime.InvokeVoidAsync("localStorageInterop.setEncrypted", key, value);
    }

    /// <summary>
    /// Retrieves an encrypted payload from localStorage and decrypts it using AES‑GCM.
    /// </summary>
    /// <param name="key">The key whose encrypted value should be decrypted and returned.</param>
    /// <returns>The decrypted plaintext string, or null if the key does not exist.</returns>
    public ValueTask<string?> GetEncryptedAsync(string key)
    {
        return _jsRuntime.InvokeAsync<string?>("localStorageInterop.getEncrypted", key);
    }
}