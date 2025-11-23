using Microsoft.OpenApi.Models;

namespace BodeTrack.API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddApiKeySwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition("X-API-KEY", new OpenApiSecurityScheme
                {
                    Name = "X-API-KEY",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "ApiKeyScheme",
                    In = ParameterLocation.Header,
                    Description = "ApiKey must appear in header"
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "X-API-KEY"
                        },
                        In = ParameterLocation.Header
                    },
                    Array.Empty<string>()
                }
            });
            });

            return services;
        }
    }
}
