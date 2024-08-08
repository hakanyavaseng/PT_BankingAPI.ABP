using AutoMapper;
using Piton.Banking.DTOs.Accounts;
using Piton.Banking.DTOs.Customers;
using Piton.Banking.DTOs.DebitCards;
using Piton.Banking.Entities.Accounts;
using Piton.Banking.Entities.Customers;
using Piton.Banking.Entities.DebitCards;

namespace Piton.Banking;

public class BankingApplicationAutoMapperProfile : Profile
{
    public BankingApplicationAutoMapperProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CreateUpdateCustomerDto, Customer>();

        CreateMap<Account, AccountDto>();
        CreateMap<CreateUpdateAccountDto, Account>();

        CreateMap<DebitCard, DebitCardDto>().ReverseMap();
        CreateMap<CreateUpdateDebitCardDto, DebitCard>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
