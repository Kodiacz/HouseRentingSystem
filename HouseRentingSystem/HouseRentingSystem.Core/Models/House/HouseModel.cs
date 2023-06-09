﻿using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseModel
    {
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 30)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(500, MinimumLength = 50)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal), "00.00", "2000,00", ErrorMessage = "Price per month must be a positive number less then {2} leva")]
        [Required]
        [Display(Name = "Price per month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<HouseCategoryModel> Categories { get; set; } = new List<HouseCategoryModel>();
    }
}
