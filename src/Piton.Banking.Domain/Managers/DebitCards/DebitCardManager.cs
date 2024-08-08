using Piton.Banking.Entities.DebitCards;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Piton.Banking.Managers.DebitCards
{
    public class DebitCardManager : DomainService
    {
        public IRepository<DebitCard, Guid> Repository { get; }

        public DebitCardManager(IRepository<DebitCard, Guid> repository)
        {
            Repository = repository;
        }

        public async Task<DebitCard> CreateAsync(DebitCard debitCard)
        {
            DateTime result = new DateTime(2029, 10, 5);
            DateTime.TryParse(GenerateExpirationDate(), out result);
            var cardNumber = GenerateNumber(16);
            var cvv = GenerateNumber(3);

            var newDebitCard = new DebitCard(
                debitCard.CustomerId,
                debitCard.AccountId,
                debitCard.CardHolderName,
                cardNumber,
                result,
                cvv
            );

            var savedDebitCard = await Repository.InsertAsync(newDebitCard);

            return savedDebitCard;
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
