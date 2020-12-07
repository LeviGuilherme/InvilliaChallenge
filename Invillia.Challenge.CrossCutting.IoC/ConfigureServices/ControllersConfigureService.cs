using Invillia.Challenge.CrossCutting.IoC.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Invillia.Challenge.CrossCutting.IoC
{
    public static class ControllersConfigureService
    {
        public static void AddControllers(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<UnitOfWorkFilter>();
            });
        }
    }
}
