using Application.Models;

namespace Application.Events
{
    public class ConnectivityChangeEventArgs(ApiVersionInfo? apiInfo = null) : EventArgs
    {
        public bool IsReachable { get; } = !String.IsNullOrWhiteSpace(apiInfo?.ApiVersion);
        public ApiVersionInfo? ApiInfo { get; } = apiInfo;
    }
}