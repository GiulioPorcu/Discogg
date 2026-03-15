using MudBlazor.Utilities;

namespace Application.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="MudColor"/>.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="MudColor"/> to its RGBA string representation.
        /// </summary>
        /// <param name="color">
        /// The color to convert.
        /// </param>
        /// <returns>
        /// The RGBA representation of the color, or <c>null</c> if the color is <c>null</c>.
        /// </returns>
        public static string? ToRgba(this MudColor color)
            => color?.ToString(MudColorOutputFormats.RGBA);
    }
}