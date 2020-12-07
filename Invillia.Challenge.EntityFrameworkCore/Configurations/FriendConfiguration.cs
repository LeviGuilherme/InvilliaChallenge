using Invillia.Challenge.Domain.Entities.FriendsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invillia.Challenge.EntityFrameworkCore.Configurations
{
    public class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        private string _tablePrefix = string.Empty;
        private string _tableName = "Friends";

        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable(_tablePrefix + _tableName);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnType("uniqueidentifier")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.Active).IsRequired();
        }
    }
}
