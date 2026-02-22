window.themeInterop = {
    themeAttribute: 'theme',
    darkTheme: 'dark',
    lightTheme: 'light',

    /**
     * Toggles between the light and dark theme by switching the value of the theme attribute.
     */
    toggleTheme: function () {
        const html = document.documentElement;
        const other = this.getCurrentTheme() === this.darkTheme ? this.lightTheme : this.darkTheme;
        html.setAttribute(this.themeAttribute, other);
        this.setCurrentTheme(other);
    },

    /**
     * Applies the stored theme from localStorage to the document element, defaulting to light if none is stored.
     */
    applyStoredTheme: function () {
        const html = document.documentElement;
        const stored = this.getCurrentTheme();

        if (stored) {
            html.setAttribute(this.themeAttribute, stored);
        } else {
            this.setCurrentTheme(this.lightTheme);
            this.applyStoredTheme();
        }
    },

    /**
     * Stores the given theme value in localStorage.
     *
     * @param {string} theme  The theme name to persist (e.g., "light" or "dark").
     */
    setCurrentTheme: function (theme) {
        return localStorage.setItem(this.themeAttribute, theme);
    },

    /**
     * Retrieves the current theme value from localStorage.
     *
     * @returns {string|null} The stored theme value or null if none exists.
     */
    getCurrentTheme: function () {
        return localStorage.getItem(this.themeAttribute);
    },

    /**
     * Returns true if the stored theme is the dark theme.
     *
     * @returns {boolean} Whether the current theme is dark.
     */
    isDarkTheme: function () {
        return this.getCurrentTheme() === this.darkTheme;
    }
};