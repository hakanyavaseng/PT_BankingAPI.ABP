namespace Piton.Banking.Consts.Accounts
{
    public static class AccountConsts
    {
        public const int AccountNameMaxLength = 50;

        public const int AccountNumberMaxLength = 10;
        public const int AccountNumberMinLength = 10;

        public const int IBANMinLength = 26;
        public const int IBANMaxLength = 26;
        public const string IBANDefaultValue = "XX000000000000000000000000";

        public const decimal MinBalance = 0;  
    }
}
