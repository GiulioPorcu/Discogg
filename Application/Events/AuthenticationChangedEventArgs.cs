using Application.Models;

namespace Application.Events
{
    public class AuthenticationChangedEventArgs(User? user = null) : EventArgs
    {
        public bool IsAuthenticated { get; } = user?.Id != null;
        public User? User { get; } = user;
    }
}