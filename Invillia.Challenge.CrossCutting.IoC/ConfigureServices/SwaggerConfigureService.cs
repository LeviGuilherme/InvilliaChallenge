using Microsoft.Extensions.DependencyInjection;

namespace Invillia.Challenge.CrossCutting.IoC
{
    public static class SwaggerConfigureService
    {
        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Invillia Challenge",
                    Description = "Teste para vaga de Desenvolvedor."
                });
            });
        }
    }
}
