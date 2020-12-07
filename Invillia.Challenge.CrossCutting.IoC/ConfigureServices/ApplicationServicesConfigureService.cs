using Invillia.Challenge.Application.Interfaces;
using Invillia.Challenge.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Invillia.Challenge.CrossCutting.IoC
{
    public static class ApplicationServicesConfigureService
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IFriendService, FriendService>();
        }
    }
}
