using Piton.Banking.Entities.Accounts;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Piton.Banking.Managers.Accounts
{
    public class AccountManager : DomainService
    {
        public IRepository<Account, Guid> Repository { get; }

        public AccountManager(IRepository<Account, Guid> repository)
        {
            Repository = repository;
        }


        public async Task<Account> CreateAccount(Account account)
        {
            var newAccount = new Account(
                account.Customer,
                account.CustomerId,
                account.AccountName,
                account.Balance
            );

            var savedAccount = await Repository.InsertAsync(newAccount, autoSave: true);
            savedAccount.IBAN = GenerateIban("1234", "5678", savedAccount.AccountNumber);
            await Repository.UpdateAsync(savedAccount);

            return savedAccount;
        }

        #region IBAN Helper Methods
        private string GenerateIban(string bankCode, string accountNumberPrefix, string accountNumber)
        {
            string paddedAccountNumber = accountNumber.PadLeft(16, '0');
            string bban = bankCode + accountNumberPrefix + paddedAccountNumber;
            string initialIban = "TR00" + bban;
            string numericIban = ConvertToNumericIban(initialIban);
            string checkDigits = CalculateCheckDigits(numericIban);
            string iban = "TR" + checkDigits + bban;

            return iban;
        }

        private string ConvertToNumericIban(string iban)
        {
            string numericIban = "";

            foreach (char c in iban)
            {
                if (char.IsLetter(c))
                {
                    numericIban += (c - 'A' + 10).ToString();
                }
                else
                {
                    numericIban += c.ToString();
                }
            }

            return numericIban;
        }

        private string CalculateCheckDigits(string numericIban)
        {
            string rearrangedIban = numericIban.Substring(4) + numericIban.Substring(0, 4);
            string remainder = rearrangedIban;
            while (remainder.Length > 2)
            {
                int blockSize = Math.Min(remainder.Length, 9);
                int block = int.Parse(remainder.Substring(0, blockSize));
                remainder = (block % 97).ToString() + remainder.Substring(blockSize);
            }

            int mod97 = int.Parse(remainder) % 97;
            int checkDigits = 98 - mod97;

            return checkDigits.ToString("D2");
        }
        #endregion
    }
}
