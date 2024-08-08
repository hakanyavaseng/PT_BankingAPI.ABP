using Piton.Banking.Entities.CreditCards;
using Piton.Banking.Entities.DebitCards;
using Piton.Banking.Enums.Cards;
using Piton.Banking.Enums.Transactions;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Piton.Banking.Entities.Transactions
{
    public class Transaction : AuditedAggregateRoot<Guid>
    {
        public Guid? DebitCardId { get; set; }
        public Guid? CreditCardId { get; set; }
        public DebitCard DebitCard { get; set; }
        public CreditCard CreditCard { get; set; }
        public TransactionType TransactionType { get; set; }
        public CardType CardType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
