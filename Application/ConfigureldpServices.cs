using System.Reflection;
//using Application.General;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Application;

public static class ConfigureIdpServices
{

    public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {

        var ChoosenAuthenticationServer = configuration["IdentityProvider:AuthenticationServer"];

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.Authority = configuration[ChoosenAuthenticationServer + ":Authority"];
            o.Audience = configuration[ChoosenAuthenticationServer + ":Audience"];
            o.RequireHttpsMetadata = false;
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminSecure", policy => policy.RequireRole("admin"));
            options.AddPolicy("UserSecure", policy => policy.RequireRole("user"));
        });

        return services;
    }
}