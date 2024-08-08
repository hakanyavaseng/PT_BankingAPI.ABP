using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Piton.Banking.Entities.DebitCards;

namespace Piton.Banking.Configurations
{
    public class DebitCardConfigurations : IEntityTypeConfiguration<DebitCard>
    {
        public void Configure(EntityTypeBuilder<DebitCard> builder)
        {
            builder.HasKey(dc => dc.Id);

            builder.Property(dc => dc.CardNumber)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(dc => dc.CardHolderName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(dc => dc.ExpiryDate)
                .IsRequired();

            builder.Property(dc => dc.CVV)
                .IsRequired()
                .HasMaxLength(4);

            builder.HasOne(dc => dc.Customer)
                .WithMany(c => c.DebitCards)
                .HasForeignKey(dc => dc.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
  
        }
    }
}
