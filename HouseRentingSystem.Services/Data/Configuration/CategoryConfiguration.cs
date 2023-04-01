namespace HouseRenting.System.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Cottage",
                },
                new Category()
                {
                    Id = 2,
                    Name = "Single-Family"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Duplex"
                },
            };
        }
    }
}
