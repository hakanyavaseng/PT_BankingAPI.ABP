
using Piton.Banking.DTOs.Accounts;
using Piton.Banking.Entities.Accounts;
using Piton.Banking.Entities.CreditCards;
using Piton.Banking.Entities.Customers;
using Piton.Banking.Entities.DebitCards;
using Piton.Banking.Helpers;
using Piton.Banking.Managers.Accounts;
using Piton.Banking.Managers.CreditCards;
using Piton.Banking.Managers.Customers;
using Piton.Banking.Managers.DebitCards;
using Piton.Banking.Services.Customers;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Piton.Banking.Services.Accounts
{
    public class BankingAccountAppService : BankingAppService, IAccountAppService
    {
        private AccountManager AccountManager { get; }
        private CustomerManager CustomerManager { get; }
        private DebitCardManager DebitCardManager { get; }
        private CreditCardManager CreditCardManager { get; }

        public BankingAccountAppService(AccountManager accountManager, CustomerManager customerManager, DebitCardManager debitCardManager, CreditCardManager creditCardManager)
        {
            AccountManager = accountManager;
            CustomerManager = customerManager;
            DebitCardManager = debitCardManager;
            CreditCardManager = creditCardManager;
        }

        public async Task<AccountDto> CreateAsync(CreateUpdateAccountDto input)
        {
            //Customer check
            Customer? customer = await CustomerManager.GetByIdAsync(input.CustomerId);
            if(customer is null)
                throw new BusinessException("Customer not found"); // TODO: Localize
            
            //Account creation
            Account account = ObjectMapper.Map<CreateUpdateAccountDto, Account>(input);
            account.Customer = customer;
            Account addedAccount = await AccountManager.CreateAccount(account);

            //Debit card creation
            var debitCard = new DebitCard()
            {
                CustomerId = customer.Id,
                AccountId = addedAccount.Id,
                CardHolderName = addedAccount.Customer.FullName,
            };
            DebitCard addedDebitCard = await DebitCardManager.CreateAsync(debitCard);

            //Credit card creation
            var creditCard = new CreditCard()
            {
                CustomerId = customer.Id,
                CardHolderName = addedAccount.Customer.FullName,
                Limit = customer.RiskLimit
            };
            CreditCard addedCreditCard = await CreditCardManager.CreateAsync(creditCard);
            
            return ObjectMapper.Map<Account, AccountDto>(addedAccount);            
        }

        public async Task DeleteAsync(Guid id)
        {
            Account? account = await AccountManager.Repository.GetAsync(id);
            if(account is null)
                throw new BusinessException("Account not found"); // TODO: Localize
            await AccountManager.Repository.DeleteAsync(account);    
        }

        public Task<AccountDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
            
        }

        public Task<PagedResultDto<AccountDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<AccountDto> UpdateAsync(Guid id, CreateUpdateAccountDto input)
        {
            throw new NotImplementedException();
        }
    }
}
