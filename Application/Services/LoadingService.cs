namespace Application.Services
{
    public class LoadingService
    {
        public event Action? OnChanged;
        public int Counter { get; private set; }

        public void Start()
        {
            this.Counter++;
            this.OnChanged?.Invoke();
        }

        public void Stop()
        {
            this.Counter = Math.Max(0, this.Counter - 1);
            this.OnChanged?.Invoke();
        }

        public bool IsLoading => this.Counter > 0;
    }
}
