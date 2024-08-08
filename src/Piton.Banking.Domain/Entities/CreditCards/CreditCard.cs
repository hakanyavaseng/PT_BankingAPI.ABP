using Piton.Banking.Entities.Common;
using Piton.Banking.Entities.Customers;
using System;

namespace Piton.Banking.Entities.CreditCards
{
    public class CreditCard : Card
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Limit { get; set; }

        public CreditCard() : base("0000000000000000", "XXX", DateTime.Now, "XXX")
        {
            
        }
        internal CreditCard(
            Guid customerId,
            string cardHolderName,
            string cardNumber,
            DateTime expiryDate,
            string cvv,
            decimal limit)
            : base(cardNumber, cardHolderName, expiryDate, cvv)
        {
            CustomerId = customerId;
            Limit = limit;
        }
        
    }
}
