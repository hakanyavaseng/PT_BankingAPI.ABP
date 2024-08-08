using Piton.Banking.DTOs.CreditCards;
using Piton.Banking.Entities.CreditCards;
using Piton.Banking.Managers.CreditCards;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Piton.Banking.Services.CreditCards
{
    public class CreditCardAppService : BankingAppService, ICreditCardAppService
    {
        private readonly CreditCardManager _creditCardManager;

        public CreditCardAppService(CreditCardManager creditCardManager)
        {
            _creditCardManager = creditCardManager;
        }

        public async Task<CreditCardDto> CreateAsync(CreateUpdateCreditCardDto input)
        {
            CreditCard? card = ObjectMapper.Map<CreateUpdateCreditCardDto, CreditCard>(input);
            var addedCard = await _creditCardManager.CreateAsync(card);
            return ObjectMapper.Map<CreditCard, CreditCardDto>(addedCard);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CreditCardDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<CreditCardDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<CreditCardDto> UpdateAsync(Guid id, CreateUpdateCreditCardDto input)
        {
            throw new NotImplementedException();
        }
    }
}
