using Piton.Banking.DTOs.Customers;
using Piton.Banking.Entities.Customers;
using Piton.Banking.Managers.Customers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Piton.Banking.Services.Customers
{
    public class CustomerAppService : BankingAppService, ICustomerAppService
    {
        CustomerManager CustomerManager { get; }

        public CustomerAppService(CustomerManager customerManager)
        {
            CustomerManager = customerManager;
        }

        public async Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input)
        {
            var mapped = ObjectMapper.Map<CreateUpdateCustomerDto, Customer>(input);
            var customer = await CustomerManager.CreateAsync(mapped);         
            return ObjectMapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task DeleteAsync(Guid id)
        {
            Customer? customer = await CustomerManager.Repository.GetAsync(id);
            if (customer is null)
                throw new BusinessException("Customer not found."); // TODO : Localize

            await CustomerManager.Repository.DeleteAsync(id);
        }

        public async Task<CustomerDto> GetAsync(Guid id)
        {
            Customer? customer = await CustomerManager.Repository.GetAsync(id);
            if (customer is null)
                throw new BusinessException("Customer not found."); // TODO : Localize

            return ObjectMapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task<PagedResultDto<CustomerDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            List<Customer> customers = await CustomerManager.Repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
            return new PagedResultDto<CustomerDto>
            {
                TotalCount = customers.Count,
                Items = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customers)
            };
        }

        public async Task<CustomerDto> UpdateAsync(Guid id, CreateUpdateCustomerDto input)
        {
            Customer? selectedCustomer = await CustomerManager.Repository.GetAsync(id);
            if(selectedCustomer is null)
                throw new BusinessException("Customer not found."); // TODO : Localize

            ObjectMapper.Map(input, selectedCustomer);
            Customer? updatedCustomer = await CustomerManager.Repository.UpdateAsync(selectedCustomer);

            return ObjectMapper.Map<Customer, CustomerDto>(updatedCustomer);     
        }
    }
}
