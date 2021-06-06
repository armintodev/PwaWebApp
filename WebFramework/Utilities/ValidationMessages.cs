namespace WebFramework.Utilities
{
    public record ValidationMessages
    {
        public const string Required = "مقدار {0} نباید خالی باشد.";
        public const string CheckPassword = "پسورد ها مطابقت ندارند";
        public const string WrongPhoneNumber = "شماره همراه درست وارد کنید.";
        public const string WrongEmail = "ایمیل را درست وارد کنید.";
        public const string WrongMaxLength = "مقدار {0} نمیتواند از {1} بیشتر باشد.";
    }
}
