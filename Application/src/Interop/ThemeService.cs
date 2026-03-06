using Microsoft.JSInterop;

namespace Application.src.Interop;

/// <summary>
/// Provides access to client-side theme operations via JavaScript interop.
/// </summary>
public class ThemeService(IJSRuntime jsRuntime)
{
    /// <summary>
    /// Determines whether the current theme stored on the client is the dark theme.
    /// </summary>
    /// <returns>
    /// A boolean indicating whether the stored theme is dark.
    /// </returns>
    public Task<bool> IsDarkThemeAsync()
    {
        return jsRuntime.InvokeAsync<bool>("themeInterop.isDarkTheme").AsTask();
    }

    public Task SetThemeAsync(string theme)
    {
        return jsRuntime.InvokeVoidAsync("themeInterop.setTheme", theme).AsTask();
    }

    public Task<string> GetThemeAsync(string theme)
    {
        return jsRuntime.InvokeAsync<string>("themeInterop.getTheme").AsTask();
    }
}