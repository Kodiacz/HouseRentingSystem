namespace HouseRentingSystem.Services.Data.Entities
{
    public class Category
    {
        public Category()
        {
            this.Houses = new HashSet<House>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<House> Houses { get; set; }
    }
}
