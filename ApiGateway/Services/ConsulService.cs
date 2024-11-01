using Consul;

namespace ApiGateway.Services;

public static class ConsulService
{
    public static void RegisterService(ConsulClient consulClient, string serviceName, string address, int port)
    {
        var registration = new AgentServiceRegistration
        {
            ID = $"{serviceName}-{Guid.NewGuid()}",
            Name = serviceName,
            Address = address,
            Port = port
        };
        consulClient.Agent.ServiceRegister(registration).Wait();
    }
}
