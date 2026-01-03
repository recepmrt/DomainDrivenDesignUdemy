using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesign.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register application services here
        services.AddMediatR(cfr => { cfr.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });

        return services;
    }
}