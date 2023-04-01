namespace HouseRentingSystem.Services.Models.House
{
    public class HouseServiceModel : IHouseModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;

        public string Address { get; init; } = null!;

        [Display(Name = HouseImageDisplayName)]
        public string ImageUrl { get; init; } = null!;

        [Display(Name = HousePricePerMonthDisplayName)]
        public decimal PricePerMonth { get; init; }

        [Display(Name = "Is Rented")]
        public bool IsRented { get; init; }
    }
}