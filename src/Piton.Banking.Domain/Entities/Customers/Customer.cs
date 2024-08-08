using Piton.Banking.Consts.Customers;
using Piton.Banking.Entities.DebitCards;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Piton.Banking.Entities.Customers
{
    public class Customer : AuditedAggregateRoot<Guid>
    {

        public ICollection<DebitCard> DebitCards { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string BirthPlace { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal RiskLimit { get; set; } = CustomerConsts.RiskLimitDefaultValue;

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        internal Customer(
            ICollection<DebitCard> debitCards, 
            string firstName, string lastName, 
            string identityNumber, 
            string birthPlace, 
            DateTime birthDate, 
            decimal riskLimit)
        {
            DebitCards = Check.NotNull(debitCards, nameof(debitCards));
            FirstName = Check.NotNullOrWhiteSpace(firstName, nameof(firstName), CustomerConsts.FirstNameMaxLength, CustomerConsts.FirstNameMinLength);
            LastName = Check.NotNullOrWhiteSpace(lastName, nameof(lastName), CustomerConsts.LastNameMaxLength, CustomerConsts.LastNameMinLength);
            IdentityNumber = Check.NotNullOrWhiteSpace(identityNumber, nameof(identityNumber), CustomerConsts.IdentityNumberMaxLength, CustomerConsts.IdentityNumberMinLength);
            BirthPlace = Check.NotNullOrWhiteSpace(birthPlace, nameof(birthPlace), CustomerConsts.BirthPlaceMaxLength, CustomerConsts.BirthPlaceMinLength);
            BirthDate = Check.NotNull(birthDate, nameof(birthDate)) > DateTime.UtcNow ? throw new BusinessException() : birthDate;
            RiskLimit = (riskLimit < 0) ? throw new BusinessException() : riskLimit;
        }
        protected Customer()
        {
            DebitCards = new HashSet<DebitCard>();
        }

    }
}
