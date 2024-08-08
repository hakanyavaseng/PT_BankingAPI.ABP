using System;
using Volo.Abp.Application.Dtos;

namespace Piton.Banking.DTOs.CreditCards
{
    public class CreditCardDto : AuditedEntityDto<Guid>
    {
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string Cvv { get; set; }
        public decimal Limit { get; set; }
    }
}
