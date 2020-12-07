using Invillia.Challenge.Domain.Entities.FriendsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invillia.Challenge.EntityFrameworkCore.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        private string _tablePrefix = string.Empty;
        private string _tableName = "Addresses";

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(_tablePrefix + _tableName);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnType("uniqueidentifier")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(e => e.Street);
            builder.Property(e => e.Number);
            builder.Property(e => e.Neighbohood);
            builder.Property(e => e.City);
            builder.Property(e => e.State);
            builder.Property(e => e.Country);
            builder.Property(e => e.PostalCode);
            builder.Property(e => e.Active).IsRequired();

            builder
                .HasOne(a => a.Friend)
                .WithMany(f => f.Addresses)
                .HasForeignKey(p => p.FriendId);
        }
    }
}
