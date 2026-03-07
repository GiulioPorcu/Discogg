namespace Application.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="ValueTask" /> related classes and objects.
    /// </summary>
    public static class ValueTaskExtensions
    {
        /// <summary>
        /// Executes the task without awaiting it.
        /// </summary>
        /// <remarks>
        /// <param name="task">The task to execute.</param>
        public static void FireAndForget(this ValueTask task) { }
    }
}