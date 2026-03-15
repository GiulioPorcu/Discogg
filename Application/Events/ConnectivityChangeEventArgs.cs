using Application.Models;

namespace Application.Events
{
    /// <summary>
    /// Provides data for connectivity state changes.
    /// </summary>
    /// <param name="apiInfo">
    /// The API version information, or <c>null</c> if unreachable.
    /// </param>
    public class ConnectivityChangeEventArgs(ApiVersionInfo? apiInfo = null) : EventArgs
    {
        /// <summary>
        /// Gets a value indicating whether the API is reachable.
        /// </summary>
        public bool IsReachable { get; } = !String.IsNullOrWhiteSpace(apiInfo?.ApiVersion);

        /// <summary>
        /// Gets the API version information associated with the connectivity change.
        /// </summary>
        public ApiVersionInfo? ApiInfo { get; } = apiInfo;
    }
}