using Invillia.Challenge.CrossCutting.IoC.Filters;
using Invillia.Challenge.Domain.RepositoryContracts;
using Invillia.Challenge.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Guids;

namespace Invillia.Challenge.CrossCutting.IoC
{
    public class NativeInjector
    {
        private static IConfiguration _configuration;

        public static void Setup(IServiceCollection services, IConfiguration configuration = null)
        {
            _configuration = configuration;

            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            ControllersConfigureService.AddControllers(services);
            CorsConfigureService.AddCors(services);
            AuthenticationConfigureService.AddAuthentication(services);
            RepositoriesConfigureService.AddRepositories(services);
            ApplicationServicesConfigureService.AddServices(services);
            DbContextConfigureService.AddDbContext(services, _configuration);
            SwaggerConfigureService.AddSwagger(services);
            AutoMapperConfigureService.AddAutoMapper(services);

            services.AddTransient<IGuidGenerator, SequentialGuidGenerator>();
            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
            services.AddScoped<ModelValidationFilterAttribute>();
        }
    }
}
