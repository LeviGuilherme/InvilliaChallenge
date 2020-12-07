using Invillia.Challenge.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Invillia.Challenge.CrossCutting.IoC
{
    public static class DbContextConfigureService
    {
        public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("AppConnection"),
                    opts => opts.MigrationsAssembly("Invillia.Challenge.EntityFrameworkCore.Migrations"));
            });
        }
    }
}
