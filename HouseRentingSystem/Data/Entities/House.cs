namespace HouseRentingSystem.Data.Entities
{
    using Humanizer;
    using System.ComponentModel.DataAnnotations;

    public class House
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 30)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(500, MinimumLength = 30)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal PricePerMonth { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        [Required]
        public int AgentId { get; set; }

        public Agent Agent { get; set; } = null!;

        public string? RenterId { get; set; }
    }
}