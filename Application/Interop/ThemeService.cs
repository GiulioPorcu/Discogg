using Microsoft.JSInterop;

namespace Application.Interop;

/// <summary>
/// Provides access to client-side theme operations via JavaScript interop.
/// </summary>
public class ThemeService(IJSRuntime _jsRuntime)
{
    /// <summary>
    /// Determines whether the current theme stored on the client is the dark theme.
    /// </summary>
    /// <returns>
    /// A boolean indicating whether the stored theme is dark.
    /// </returns>
    public Task<bool> IsDarkThemeAsync()
    {
        return _jsRuntime.InvokeAsync<bool>("themeInterop.isDarkTheme").AsTask();
    }

    /// <summary>
    /// Toggles the client-side theme between light and dark.
    /// </summary>
    public Task ToggleThemeAsync()
    {
        return _jsRuntime.InvokeVoidAsync("themeInterop.toggleTheme").AsTask();
    }
}