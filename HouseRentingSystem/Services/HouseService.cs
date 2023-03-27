namespace HouseRentingSystem.Services
{
    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext dbContext;

        public HouseService(HouseRentingDbContext context)
        {
            this.dbContext = context;
        }

        public HouseQueryServiceModel All(
            string? category = null, 
            string? searchTerm = null, 
            HouseSorting sorting = HouseSorting.Newest, 
            int currentPage = 1, 
            int housesPerPage = 1)
        {
            var housesQuery = this.dbContext.Houses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category) )
            {
                housesQuery = this.dbContext.Houses
                    .Where(h => h.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm) )
            {
                housesQuery = housesQuery.Where(h =>
                    h.Title.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Address.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            housesQuery = sorting switch
            {
                HouseSorting.Price => housesQuery.OrderBy(h => h.PricePerMonth),
                HouseSorting.NotRentedFirst => housesQuery.OrderBy(h => h.RenterId != null).ThenByDescending(h => h.Id),
                _ => housesQuery.OrderByDescending(h => h.Id),  
            };

            var houses = housesQuery
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(h => new HouseServiceModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerMonth = h.PricePerMonth,
                })
                .ToList();

            var totalHouses = housesQuery.Count();

            return new HouseQueryServiceModel()
            {
                TotalHousesCount = totalHouses,
                Houses = houses,
            };
        }

        public IEnumerable<HouseCategoryServiceModel> AllCategories()
        {
            return this.dbContext
                .Categories
                .Select(c => new HouseCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToList();
        }

        public IEnumerable<string> AllCategoriesNames()
        {
            return this.dbContext
                .Categories
                    .Select(c => c.Name)
                    .Distinct()
                    .ToList();
        }

        public bool CategoryExists(int categoryId)
        {
            return this.dbContext
                .Categories.Any(c => c.Id == categoryId);
        }

        public int Create(HouseFormModel houseModel, int agentId)
        {
            var house = new House() 
            {
                Title = houseModel.Title,
                Address = houseModel.Address,
                Description = houseModel.Description,
                ImageUrl = houseModel.ImageUrl,
                PricePerMonth = houseModel.PricePerMonth,
                CategoryId = houseModel.CategoryId,
                AgentId = agentId,
            };

            this.dbContext.Houses.Add(house);
            this.dbContext.SaveChanges();

            return house.Id;
        }

        public IEnumerable<HouseIndexServiceModel> LastThreeHouses()
        {
            return this.dbContext
                .Houses
                .OrderByDescending(h => h.Id)
                .Select(h => new HouseIndexServiceModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl,
                })
                .Take(3)
                .ToList();
        }
    }
}


