using Piton.Banking.DTOs.Accounts;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Piton.Banking.Services.Accounts
{
    public interface IAccountAppService : ICrudAppService<AccountDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateAccountDto>
    {

    }
}
