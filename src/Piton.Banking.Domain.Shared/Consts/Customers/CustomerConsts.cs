using System;

namespace Piton.Banking.Consts.Customers
{
    public static class CustomerConsts
    {
        public const int FirstNameMaxLength = 50;
        public const int FirstNameMinLength = 3;

        public const int LastNameMaxLength = 50;
        public const int LastNameMinLength = 3;

        public const int IdentityNumberMaxLength = 11;
        public const int IdentityNumberMinLength = 11;

        public const int BirthPlaceMaxLength = 50;
        public const int BirthPlaceMinLength = 3;

        public const decimal RiskLimitDefaultValue = 10000;
    }
}
