using Piton.Banking.DTOs.DebitCards;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Piton.Banking.Services.DebitCards
{
    public interface IDebitCardAppService : ICrudAppService<DebitCardDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDebitCardDto>
    {
    }
}
