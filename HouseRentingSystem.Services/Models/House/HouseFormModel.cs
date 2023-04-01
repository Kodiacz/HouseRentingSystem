namespace HouseRentingSystem.Services.Models.House
{
    public class HouseFormModel : IHouseModel
    {
        public HouseFormModel()
        {
            this.Categories = new List<HouseCategoryServiceModel>();
        }

        [Required]
        [StringLength(HouseTitleMaxLength, MinimumLength = HouseTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(HouseAddressMaxLength, MinimumLength = HouseAddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(HouseDescriptionMaxLength, MinimumLength = HouseDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = HouseImageDisplayName)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = HousePricePerMonthDisplayName)]
        [Range((double)HousePricePerMonthMinValue, (double)HousePricePerMonthMaxValue, 
            ErrorMessage = HousePricePerMonthErrorMessage)]
        public decimal PricePerMonth { get; set; }

        [Display(Name = HouseCategoryDisplayName)]
        public int CategoryId { get; set; }

        public IEnumerable<HouseCategoryServiceModel> Categories { get; set; }
    }
}
