window.themeInterop = {
    themeAttribute: 'data-theme',
    darkTheme: 'dark',
    lightTheme: 'light',

    /**
     * Stores the given theme value in localStorage.
     *
     * @param {string} theme  The theme name to persist (e.g., "light" or "dark").
     */
    setTheme: function (theme) {
        const html = document.documentElement;
        html.setAttribute(this.themeAttribute, theme);
        return localStorage.setItem(this.themeAttribute, theme);
    },

    /**
     * Retrieves the current theme value from localStorage.
     *
     * @returns {string|null} The stored theme value or null if none exists.
     */
    getTheme: function () {
        return localStorage.getItem(this.themeAttribute);
    },

    /**
     * Returns true if the stored theme is the dark theme.
     *
     * @returns {boolean} Whether the current theme is dark.
     */
    isDarkTheme: function () {
        return this.getTheme() === this.darkTheme;
    }
};