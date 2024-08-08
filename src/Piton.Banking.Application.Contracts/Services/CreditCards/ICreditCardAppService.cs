using Piton.Banking.DTOs.CreditCards;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Piton.Banking.Services.CreditCards
{
    public interface ICreditCardAppService : ICrudAppService<CreditCardDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCreditCardDto>
    {
    }
}
