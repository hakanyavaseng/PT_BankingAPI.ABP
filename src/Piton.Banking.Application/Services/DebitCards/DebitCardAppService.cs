using Piton.Banking.DTOs.DebitCards;
using Piton.Banking.Entities.DebitCards;
using Piton.Banking.Managers.DebitCards;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Uow;

namespace Piton.Banking.Services.DebitCards
{
    public class DebitCardAppService : BankingAppService, IDebitCardAppService
    {
        private readonly DebitCardManager _debitCardManager;

        public DebitCardAppService(DebitCardManager debitCardManager)
        {
            _debitCardManager = debitCardManager;
        }

        public async Task<DebitCardDto> CreateAsync(CreateUpdateDebitCardDto input)
        {
            DebitCard debitCard = ObjectMapper.Map<CreateUpdateDebitCardDto, DebitCard>(input);
            var addedDebitCard = await _debitCardManager.CreateAsync(debitCard);
            return ObjectMapper.Map<DebitCard, DebitCardDto>(addedDebitCard);
            
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DebitCardDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<DebitCardDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var debitCards = await _debitCardManager.Repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
            return new PagedResultDto<DebitCardDto>(
                debitCards.Count,
                ObjectMapper.Map<List<DebitCard>, List<DebitCardDto>>(debitCards));
        }

        public Task<DebitCardDto> UpdateAsync(Guid id, CreateUpdateDebitCardDto input)
        {
            throw new NotImplementedException();
        }
    }
}
