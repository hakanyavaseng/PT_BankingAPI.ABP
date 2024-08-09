using Piton.Banking.DTOs.Customers;
using Piton.Banking.Entities.Customers;
using Piton.Banking.Managers.Customers;
using Piton.Banking.Repositories.Customers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Piton.Banking.Services.Customers
{
    public class CustomerAppService : BankingAppService, ICustomerAppService
    {
        CustomerManager CustomerManager { get; }
        private readonly IRepository<Customer, Guid> _customerRepository;

        public CustomerAppService(CustomerManager customerManager, IRepository<Customer, Guid> customerRepository)
        {
            CustomerManager = customerManager;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input)
        {
            var mapped = ObjectMapper.Map<CreateUpdateCustomerDto, Customer>(input);
            var customer = await CustomerManager.CreateAsync(mapped);         
            return ObjectMapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task DeleteAsync(Guid id)
        {
            Customer? customer = await CustomerManager.GetByIdAsync(id);
            if (customer is null)
                throw new BusinessException("Customer not found."); // TODO : Localize

            await _customerRepository.DeleteAsync(id);
        }

        public async Task<CustomerDto> GetAsync(Guid id)
        {
            Customer? customer = await _customerRepository.GetAsync(id);
            if (customer is null)
                throw new BusinessException("Customer not found."); // TODO : Localize

            return ObjectMapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task<PagedResultDto<CustomerDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            List<Customer> customers = await _customerRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
            return new PagedResultDto<CustomerDto>
            {
                TotalCount = customers.Count,
                Items = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customers)
            };
        }

        public async Task<CustomerDto> UpdateAsync(Guid id, CreateUpdateCustomerDto input)
        {
            Customer? selectedCustomer = await _customerRepository.GetAsync(id);
            if(selectedCustomer is null)
                throw new BusinessException("Customer not found."); // TODO : Localize

            ObjectMapper.Map(input, selectedCustomer);
            Customer? updatedCustomer = await _customerRepository.UpdateAsync(selectedCustomer);

            return ObjectMapper.Map<Customer, CustomerDto>(updatedCustomer);     
        }
    }
}
