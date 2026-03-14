using MudBlazor;
using MudBlazor.Utilities;

namespace Application.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="Color" />, <see cref="MudColor" /> related classes and objects.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Returns the color as an RGBA-formatted string.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>The RGBA string representation of the color.</returns>
        public static string? ToRgba(this MudColor color) 
            => color?.ToString(MudColorOutputFormats.RGBA);
    }
}