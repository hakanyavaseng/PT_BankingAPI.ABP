using Piton.Banking.Entities.Customers;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Piton.Banking.Managers.Customers
{
    public class CustomerManager : DomainService
    {
        public IRepository<Customer, Guid> Repository { get; }
        public CustomerManager(IRepository<Customer, Guid> repository)
        {
            Repository = repository;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            var existingCustomer = await Repository.FirstOrDefaultAsync(x => x.IdentityNumber == customer.IdentityNumber);
            if (existingCustomer != null)
                throw new BusinessException("Customer with this identity number already exists."); // TODO : Localize

            var newCustomer = new Customer (
                customer.DebitCards,
                customer.FirstName,
                customer.LastName,
                customer.IdentityNumber,
                customer.BirthPlace,
                customer.BirthDate,
                customer.RiskLimit
            );
            return await Repository.InsertAsync(newCustomer);
        }
    }
}
