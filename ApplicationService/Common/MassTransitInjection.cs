using Core;
using MassTransit;

namespace ApplicationService.Common;

internal static class MassTransitInjection
{
    internal static IServiceCollection AddConfiguredMassTransit(this IServiceCollection services,
        IConfiguration configuration)
    {
        var rabbitOption = new RabbitMqConfig();
        configuration.GetSection(RabbitMqConfig.Key).Bind(rabbitOption);
        services.AddMassTransit(x =>
            {
                x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("app"));

                // Clients
                x.AddRequestClient<SendMessageBusRequest>();

                // Consumers
                // x.AddConsumer<Consumer>();

                x.UsingRabbitMq((context, config) =>
                {
                    config.Host(new Uri(rabbitOption.Host), h =>
                        {
                            h.Username(rabbitOption.Username);
                            h.Password(rabbitOption.Password);

                            if (rabbitOption.ClusterEnabled)
                            {
                                h.UseCluster(c =>
                                {
                                    foreach (var node in rabbitOption.ClusterNodes)
                                        c.Node(node);
                                });
                            }
                        }
                    );
                    config.AutoStart = true;
                    config.ConfigureEndpoints(context);
                });
            }
        );
        return services;
    }
}