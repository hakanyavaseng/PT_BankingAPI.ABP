using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Piton.Banking.Entities.Accounts;

namespace Piton.Banking.Configurations
{
    public class AccountConfigurations : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(p => p.Balance)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.AccountName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(p => p.AccountNumber)
                .IsUnique();

            builder.Property(p => p.AccountNumber)
                .HasMaxLength(10)
                .HasDefaultValueSql("NEXT VALUE FOR AccountNumberSequence");
        }
    }
}
