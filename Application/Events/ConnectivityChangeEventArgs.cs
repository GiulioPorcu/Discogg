using Application.Models;

namespace Application.Events
{
    public class ConnectivityChangeEventArgs(ApiInfo? apiInfo = null) : EventArgs
    {
        public bool IsReachable { get; } = !String.IsNullOrWhiteSpace(apiInfo?.ApiVersion);
        public ApiInfo? ApiInfo { get; } = apiInfo;
    }
}