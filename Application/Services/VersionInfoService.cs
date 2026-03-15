using Application.Events;
using Application.Models;
using Application.Properties;
using System.Reflection;

namespace Application.Services
{
    public class VersionInfoService(DiscogsService discogsService, SerializationService serializationService)
    {
        public event EventHandler<string>? OnError;
        public event EventHandler<ConnectivityChangeEventArgs>? OnConnectivityChanged;
        public event EventHandler<string>? OnApplicationVersionFetched;

        public ApiVersionInfo? ApiInfo { get; private set; }
        public string? ApplicationVersion { get; private set; }
        public bool IsConnected => !String.IsNullOrWhiteSpace(this.ApiInfo?.ApiVersion);

        private readonly DiscogsService _discogsService = discogsService;
        private readonly SerializationService _serializationService = serializationService;

        public async Task<string?> GetApplicationVersionAsync(CancellationToken ct = default)
        {
            this.ApplicationVersion = null;

            try
            {
                ct.ThrowIfCancellationRequested();

                Assembly? assembly = Assembly.GetExecutingAssembly();
                if (assembly is null)
                {
                    return await Task.FromResult((string?)null);
                }

                AssemblyInformationalVersionAttribute? attribute = assembly
                    .GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false)
                    .OfType<AssemblyInformationalVersionAttribute>()
                    .FirstOrDefault();

                string? raw = attribute?.InformationalVersion;

                if (String.IsNullOrWhiteSpace(raw))
                {
                    return await Task.FromResult((string?)null);
                }
                string numericPart = raw.Split('-', '+')[0];

                if (!Version.TryParse(numericPart, out Version? version))
                {
                    return await Task.FromResult((string?)null);
                }

                string normalized = $"{version.Major}.{version.Minor}";

                this.ApplicationVersion = normalized;
                this.OnApplicationVersionFetched?.Invoke(this, normalized);
                return await Task.FromResult(normalized);
            }
            catch (Exception exception)
            {
                this.OnError?.Invoke(this, exception.Message);
                return null;
            }
        }

        public async Task<ApiVersionInfo?> GetApiInfoAsync(CancellationToken ct = default)
        {
            this.ApiInfo = null;
            this.OnConnectivityChanged?.Invoke(this, new ConnectivityChangeEventArgs(null));

            try
            {
                string url = DiscogsService.AssembleUri(String.Empty);
                using HttpResponseMessage? responseMessage = await this._discogsService.DoRequestAsync(HttpMethod.Get, url, content: null, ct) ?? throw new Exception(Messages.WebRequestFailed);

                if (responseMessage.IsSuccessStatusCode && await this._serializationService.DeserializeAsync<ApiVersionInfo>(responseMessage, ct) is ApiVersionInfo connectionInfo)
                {
                    this.ApiInfo = connectionInfo;
                    this.OnConnectivityChanged?.Invoke(this, new ConnectivityChangeEventArgs(connectionInfo));
                }
            }
            catch (Exception exception)
            {
                this.OnError?.Invoke(this, exception.Message);
            }

            return this.ApiInfo;
        }
    }
}