using AutoMapper;
using Invillia.Challenge.Application.AutoMapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace Invillia.Challenge.CrossCutting.IoC
{
    public static class AutoMapperConfigureService
    {
        public static void AddAutoMapper(IServiceCollection services)
        {
            var mapConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<FriendProfile>();
                config.AddProfile<GameProfile>();
                config.AddProfile<GameLendProfile>();
            });
            mapConfig.AssertConfigurationIsValid();
            var mapper = mapConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
