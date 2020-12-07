using Invillia.Challenge.Domain.Entities.GamesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invillia.Challenge.EntityFrameworkCore.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        private string _tablePrefix = string.Empty;
        private string _tableName = "Games";

        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable(_tablePrefix + _tableName);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnType("uniqueidentifier")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.ManufacturingDate);
            builder.Property(e => e.PurchaseValue).HasColumnType("DECIMAL(13,2)");
            builder.Property(e => e.Version);
            builder.Property(e => e.Active).IsRequired();
        }
    }
}
