using System.Diagnostics.CodeAnalysis;

namespace Application.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="ValueTask"/>.
    /// </summary>
    public static class ValueTaskExtensions
    {
        /// <summary>
        /// Executes the <see cref="ValueTask"/> without awaiting it, suppressing any warnings.
        /// </summary>
        /// <param name="task">
        /// The task to execute in a fire‑and‑forget manner.
        /// </param>
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public static void FireAndForget(this ValueTask task) { }
    }
}