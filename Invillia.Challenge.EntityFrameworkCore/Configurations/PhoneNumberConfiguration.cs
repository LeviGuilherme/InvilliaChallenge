using Invillia.Challenge.Domain.Entities.FriendsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invillia.Challenge.EntityFrameworkCore.Configurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        private string _tablePrefix = string.Empty;
        private string _tableName = "PhoneNumbers";

        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable(_tablePrefix + _tableName);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnType("uniqueidentifier")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(e => e.WhatsApp);
            builder.Property(e => e.Mobile).IsRequired();
            builder.Property(e => e.LandLine);
            builder.Property(e => e.Active).IsRequired();

            builder
                .HasOne(p => p.Friend)
                .WithMany(f => f.PhoneNumbers)
                .HasForeignKey(p => p.FriendId);
        }
    }
}
