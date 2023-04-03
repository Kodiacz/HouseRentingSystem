namespace HouseRentingSystem.Services.Data.Entities
{
    public class House
    {
        [Key]
        public int Id { get; set; }

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
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal PricePerMonth { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [Required]
        public int AgentId { get; set; }
        public Agent Agent { get; set; } = null!;

        public string? RenterId { get; set; }
        public ApplicationUser? Renter { get; set; } 

        public bool IsDeleted { get; set; } = false;
    }
}