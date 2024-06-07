using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ConfigureApplicationServices
{
    public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly)).AddAutoMapper(assembly);
    }
}
