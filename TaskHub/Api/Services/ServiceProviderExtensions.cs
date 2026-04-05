namespace Api.Services
{
    public static class ServiceProviderExtensions
    {
        public static void CompareServices<T>(this IServiceProvider provider)
        where T : IHasInstanceId
        {
            var first = provider.GetRequiredService<T>();
            var second = provider.GetRequiredService<T>();

            Console.WriteLine($"Service: {typeof(T).Name}");
            Console.WriteLine($"First: {first.InstanceId}");
            Console.WriteLine($"Second: {second.InstanceId}");
            Console.WriteLine($"Same instance: {ReferenceEquals(first, second)}");
        }
    }
}
