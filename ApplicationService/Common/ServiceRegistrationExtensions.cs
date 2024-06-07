using FluentValidation;

namespace ApplicationService.Common;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection ConfigureValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

        return services;
    }
}