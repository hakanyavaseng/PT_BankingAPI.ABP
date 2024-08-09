using Piton.Banking.Entities.Customers;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Piton.Banking.Managers.Customers
{
    public class CustomerManager : ExtendedDomainService<Customer,Guid>
    {
        public CustomerManager(IRepository<Customer, Guid> repository) : base(repository)
        {
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
