namespace HouseRentingSystem.Data.Entities
{
    public static class DataConstants
    {
        public static class AgentConstants
        {
            public const int PhoneNumberMaxLength = 15;
            public const int PhoneNumberMinLength = 7;

            public const string PhoneNumberDisplayName = "Phone Number";
        }

        public static class ApplicationUserConstants
        {

        }

        public static class CategoryConstants
        {
            public const int CategoryNameMaxLength = 100;
        }

        public static class HouseConstants
        {
            public const int HouseTitleMaxLength = 50;
            public const int HouseTitleMinLength = 10;

            public const int HouseAddressMaxLength = 150;
            public const int HouseAddressMinLength = 30;

            public const int HouseDescriptionMaxLength = 500;
            public const int HouseDescriptionMinLength = 30;

            public const string HouseImageDisplayName = "Image URL";

            public const string HousePricePerMonthDisplayName = "Image URL";
            public const string HousePricePerMonthErrorMessage = "Proce Per Month must be a positive number and less than {2} leva";
            public const decimal HousePricePerMonthMaxValue = 2000m;
            public const decimal HousePricePerMonthMinValue = 0.0m;

            public const string HouseCategoryDisplayName = "Category";
        }
    }
}
