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

            if (!string.IsNullOrWhiteSpace(category))
            {
                housesQuery = this.dbContext.Houses
                    .Where(h => h.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
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

        public IEnumerable<HouseServiceModel> AllHousesByAgentId(int agentId)
        {
            var houses = this.dbContext
                .Houses
                .Where(h => h.AgentId == agentId)
                .ToList();

            return this.ProjectToModel(houses);
        }

        public IEnumerable<HouseServiceModel> AllHousesByUserId(string userId)
        {
            var houses = this.dbContext
                .Houses
                .Where(h => h.RenterId == userId)
                .ToList();

            return this.ProjectToModel(houses);
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

        public void Edit(
            int houseId,
            string title,
            string address,
            string description,
            string imageUrl,
            decimal price,
            int categoryId)
        {
            var house = this.dbContext.Houses.Find(houseId)!;

            house.Title = title;
            house.Address = address;
            house.Description = description;
            house.ImageUrl = imageUrl;
            house.PricePerMonth = price;
            house.CategoryId = categoryId;

            this.dbContext.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.dbContext.Houses.Any(h => h.Id == id);
        }

        public int GetHouseCategoryId(int houseId)
        {
            return this.dbContext.Houses?.Find(houseId)?.CategoryId ?? -1;
        }

        public bool HasAgentWithId(int houseId, string currentUserId)
        {
            var house = this.dbContext.Houses.Find(houseId);
            var agent = this.dbContext.Agents.FirstOrDefault(a => a.Id == house!.AgentId);

            if (agent == null)
            {
                return false;
            }

            if (agent.UserId != currentUserId)
            {
                return false;
            }

            return true;
        }

        public HouseDetailsServiceModel HouseDetailsById(int id)
        {
            return this.dbContext
                .Houses
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsServiceModel()
                {
                    Id = id,
                    Title = h.Title,
                    Address = h.Address,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId != null,
                    Category = h.Category.Name,
                    Agent = new AgentServiceModel()
                    {
                        PhoneNumber = h.Agent.PhoneNumber,
                        Email = h.Agent.User.Email,
                    }
                })
                .FirstOrDefault()!;
        }

        public bool IsRented(int id)
        {
            return this.dbContext.Houses.Find(id)?.RenterId != null;
        }

        public bool IsRentedByUserWithId(int houseId, string userId)
        {
            var house = this.dbContext.Houses.Find(houseId);

            if (house == null)
            {
                return false;
            }

            if (house.RenterId != userId)
            {
                return false;
            }

            return true;
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

        public void Leave(int houseId)
        {
            var house = this.dbContext.Houses.Find(houseId);

            house!.RenterId = null;
            this.dbContext.SaveChanges();
        }

        public void Rent(int houseId, string userId)
        {
            var house = this.dbContext.Houses.Find(houseId);

            house!.RenterId = userId;
            this.dbContext.SaveChanges();
        }

        private List<HouseServiceModel> ProjectToModel(List<House> houses)
        {
            var resultHouses = houses
                .Select(h => new HouseServiceModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    Address = h.Address,
                    IsRented = h.RenterId != null
                })
                .ToList();

            return resultHouses;
        }
    }
}


