using Piton.Banking.Entities.CreditCards;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Piton.Banking.Managers.CreditCards
{
    public class CreditCardManager : DomainService
    {
        public IRepository<CreditCard, Guid> Repository { get; }

        public CreditCardManager(IRepository<CreditCard, Guid> repository)
        {
            Repository = repository;
        }

        public async Task<CreditCard> CreateAsync(CreditCard creditCard)
        {
            DateTime.TryParse(GenerateExpirationDate(), out DateTime result);
            var cardNumber = GenerateNumber(16);
            var cvv = GenerateNumber(3);

            CreditCard card = new(
                customerId: creditCard.CustomerId,
                cardHolderName: creditCard.CardHolderName,
                cardNumber: cardNumber,
                expiryDate: result,
                cvv: cvv,
                limit: creditCard.Limit
                );

            return await Repository.InsertAsync(creditCard);
        }
        private string GenerateNumber(int size)
        {
            byte[] bytes = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            StringBuilder sb = new StringBuilder(size);
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:D2}", b % 100);
            }
            return sb.ToString().Substring(0, size);
        }

        private string GenerateExpirationDate()
        {
            return DateTime.Now.AddYears(5).ToString("MM/yyyy");
        }
    }
}
