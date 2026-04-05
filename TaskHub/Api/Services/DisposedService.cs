namespace Api.Services
{
    public abstract class DisposedService : IHasInstanceId, IDisposable
    {
        public Guid InstanceId { get; } = Guid.NewGuid();

        protected DisposedService()
        {
            Console.WriteLine($"{GetType().Name} CREATED:{InstanceId}");
        }

        public void Dispose()
        {
            Console.WriteLine($"{GetType().Name} DISPOSED: {InstanceId}");
        }
    }
}

