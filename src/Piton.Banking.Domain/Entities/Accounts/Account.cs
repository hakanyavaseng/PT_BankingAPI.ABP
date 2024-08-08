using Piton.Banking.Consts.Accounts;
using Piton.Banking.Entities.Customers;
using Piton.Banking.Entities.DebitCards;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Piton.Banking.Entities.Accounts
{
    public class Account : AuditedAggregateRoot<Guid>
    {
        public virtual Customer Customer { get; set; }
        public virtual Guid CustomerId { get; internal set; }
        public virtual string AccountName { get; internal set; }
        public virtual string AccountNumber { get; internal set; }
        public virtual string IBAN { get;  set; } = AccountConsts.IBANDefaultValue;
        public virtual decimal Balance { get; internal set; }
        public DebitCard DebitCard { get; set; }

        public Account()
        {

        }
        internal Account(
            Customer? customer, 
            Guid customerId, 
            string accountName, 
            decimal balance)
        {
            Customer = customer ?? throw new BusinessException();
            CustomerId = customerId == null ? throw new BusinessException() : customerId;
            AccountName = Check.NotNullOrWhiteSpace(accountName, nameof(customer), AccountConsts.AccountNameMaxLength);
            Balance = Check.NotNull(balance, nameof(balance));
        }
    }
}
