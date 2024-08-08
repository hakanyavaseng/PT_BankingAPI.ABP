using System;
using Volo.Abp.Application.Dtos;

namespace Piton.Banking.DTOs.Customers
{
    public class CustomerDto : AuditedEntityDto<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string BirthPlace { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal RiskLimit { get; set; }
    }
}
