using Microsoft.Extensions.DependencyInjection;

namespace Invillia.Challenge.CrossCutting.IoC
{
    internal class AuthenticationConfigureService
    {
        internal static void AddAuthentication(IServiceCollection services)
        {
            services
                .AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options => 
                {
                    options.Authority = "https://localhost:5001";
                    options.RequireHttpsMetadata = true;
                    options.Audience = "invillia.challenge.api";
                });
        }
    }
}