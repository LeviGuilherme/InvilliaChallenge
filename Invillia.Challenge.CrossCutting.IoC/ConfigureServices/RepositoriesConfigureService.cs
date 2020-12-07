using Invillia.Challenge.Domain.Repositories;
using Invillia.Challenge.EntityFrameworkCore.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Invillia.Challenge.CrossCutting.IoC
{
    public static class RepositoriesConfigureService
    {
        public static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGameLendRepository, GameLendRepository>();
        }
    }
}
