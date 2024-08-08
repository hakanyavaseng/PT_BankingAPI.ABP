using System;

namespace Piton.Banking.DTOs.Accounts
{
    public class CreateUpdateAccountDto
    {
        public Guid CustomerId { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
    }
}
