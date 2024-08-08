using Piton.Banking.Consts.Cards;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Piton.Banking.Entities.Common
{
    public class Card : AuditedAggregateRoot<Guid>
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CVV { get; set; }

        internal Card(string cardNumber, string cardHolderName, DateTime expiryDate, string cvv)
        {
            CardNumber = Check.NotNullOrWhiteSpace(cardNumber, nameof(cardNumber), CardConsts.CardNumberMaxLength, CardConsts.CardNumberMinLength);
            CardHolderName = Check.NotNullOrWhiteSpace(cardHolderName, nameof(cardHolderName), CardConsts.CardHolderNameMaxLength, CardConsts.CVVMinLength);
            ExpiryDate = Check.NotNull(expiryDate, nameof(expiryDate)) < DateTime.UtcNow ? throw new BusinessException() : expiryDate;
            CVV = Check.NotNullOrWhiteSpace(cvv, nameof(cvv), CardConsts.CVVMaxLength, CardConsts.CVVMinLength);       
        }
    }
}
