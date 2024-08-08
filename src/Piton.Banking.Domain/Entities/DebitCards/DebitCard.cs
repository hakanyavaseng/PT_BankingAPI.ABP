using Piton.Banking.Entities.Accounts;
using Piton.Banking.Entities.Common;
using Piton.Banking.Entities.Customers;
using System;

namespace Piton.Banking.Entities.DebitCards
{
    public class DebitCard : Card
    {
        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
        public Customer Customer { get; set; }
        public Account Account { get; set; }

        public DebitCard() : base("0000000000000000", "XXX", DateTime.Now, "XXX")
        {
            
        }
        internal DebitCard(
            Guid customerId, 
            Guid accountId,
            string cardHolderName,
            string cardNumber, 
            DateTime expiryDate,
            string cvv)
            : base(cardNumber, cardHolderName, expiryDate, cvv)
        {
            CustomerId = customerId;
            AccountId = accountId;
        }
    }
}
