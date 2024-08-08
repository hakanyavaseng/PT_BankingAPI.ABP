using System;

namespace Piton.Banking.DTOs.DebitCards
{
    public class CreateUpdateDebitCardDto
    {
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
