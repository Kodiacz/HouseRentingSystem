namespace HouseRentingSystem.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Houses = new HashSet<House>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public IEnumerable<House> Houses { get; set; }
    }
}
