using Invillia.Challenge.Domain.Entities;
using Invillia.Challenge.Domain.Entities.FriendsAggregate;
using Invillia.Challenge.Domain.Entities.GamesAggregate;
using Invillia.Challenge.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Invillia.Challenge.EntityFrameworkCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FriendConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNumberConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new GameLendConfiguration());
        }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<GameLend> GameLend { get; set; }
    }
}
