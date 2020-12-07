using Invillia.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invillia.Challenge.EntityFrameworkCore.Configurations
{
    public class GameLendConfiguration : IEntityTypeConfiguration<GameLend>
    {
        private string _tablePrefix = string.Empty;
        private string _tableName = "GameLends";

        public void Configure(EntityTypeBuilder<GameLend> builder)
        {
            builder.ToTable(_tablePrefix + _tableName);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnType("uniqueidentifier")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(e => e.LenddingDate).IsRequired();
            builder.Property(e => e.Active).IsRequired();

            builder
                .HasOne(gl => gl.Friend)
                .WithOne(g => g.GameLend)
                .HasForeignKey<GameLend>(gl => gl.FriendId);
            
            builder
                .HasOne(gl => gl.Game)
                .WithOne(g => g.GameLend)
                .HasForeignKey<GameLend>(gl => gl.GameId);
        }
    }
}
