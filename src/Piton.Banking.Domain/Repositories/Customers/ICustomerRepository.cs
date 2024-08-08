using Piton.Banking.Entities.Customers;
using System;
using Volo.Abp.Domain.Repositories;

namespace Piton.Banking.Repositories.Customers
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
    }
}
