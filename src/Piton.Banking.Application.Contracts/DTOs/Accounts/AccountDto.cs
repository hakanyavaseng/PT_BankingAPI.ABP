using System;
using Volo.Abp.Application.Dtos;

namespace Piton.Banking.DTOs.Accounts
{
    public class AccountDto : AuditedEntityDto<Guid>
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string IBAN { get; set; }
        public Guid CustomerId { get; set; }
    }
}
