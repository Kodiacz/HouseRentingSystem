namespace HouseRentingSystem.Models.House
{
    public class HouseServiceModel
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public string Address { get; init; }

        [Display(Name = HouseImageDisplayName)]
        public string ImageUrl { get; init; }

        [Display(Name = HousePricePerMonthDisplayName)]
        public decimal PricePerMonth { get; init; }

        [Display(Name = "Is Rented")]
        public bool IsRented { get; init; }
    }
}