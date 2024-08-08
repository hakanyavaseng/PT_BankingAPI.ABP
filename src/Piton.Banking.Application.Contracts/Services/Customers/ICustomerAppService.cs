using Piton.Banking.DTOs.Customers;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Piton.Banking.Services.Customers
{
    public interface ICustomerAppService : ICrudAppService<CustomerDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCustomerDto>
    {
    }
}
