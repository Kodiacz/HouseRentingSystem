namespace HouseRentingSystem.Infrastructure.Data.Configuration
{
    using HouseRentingSystem.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Cottage"
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

            return categories;
        }
    }
}
