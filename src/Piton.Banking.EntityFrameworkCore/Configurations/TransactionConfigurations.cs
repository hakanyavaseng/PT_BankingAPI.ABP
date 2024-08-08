using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Piton.Banking.Entities.Transactions;

namespace Piton.Banking.Configurations
{
    public class TransactionConfigurations : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(p=> p.Amount)
                .HasColumnType("decimal(18,2)")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p=> p.Description)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
