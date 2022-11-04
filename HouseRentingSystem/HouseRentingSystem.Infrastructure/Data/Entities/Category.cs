namespace HouseRentingSystem.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Houses = new List<House>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public List<House> Houses { get; set; } 
    }
}
