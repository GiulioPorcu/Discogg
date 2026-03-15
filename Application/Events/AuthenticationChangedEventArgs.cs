using Application.Models;

namespace Application.Events
{
    public class AuthenticationChangedEventArgs(OAuth? user = null) : EventArgs
    {
        public bool IsAuthenticated { get; } = user?.Id != null;
        public OAuth? OAuth { get; } = user;
    }
}