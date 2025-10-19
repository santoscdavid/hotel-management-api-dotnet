using Microsoft.OpenApi.Models;

namespace HotelManagement.API.Extensions;

public static class ApiDependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Hotel Management API",
                Version = "v1",
            });
        });

        return services;
    }
}