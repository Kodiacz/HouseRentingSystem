namespace HouseRentingSystem.Core.Services
{
    using HouseRentingSystem.Core.Contracts;
    using HouseRentingSystem.Core.Models.House;
    using HouseRentingSystem.Infrastructure.Data.Common;
    using HouseRentingSystem.Infrastructure.Data.Entities;

    using Microsoft.EntityFrameworkCore;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HouseService : IHouseService
    {
        private readonly IRepository repo;

        public HouseService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<HousesQueryModel> All(string? category = null, string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {
            var result = new HousesQueryModel();
            var houses = repo.AllReadonly<House>();

            if (string.IsNullOrEmpty(category) == false)
            {
                houses = houses
                    .Where(h => h.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";
                houses = houses
                    .Where(h => EF.Functions.Like(h.Title.ToLower(), searchTerm) ||
                    EF.Functions.Like(h.Address.ToLower(), searchTerm) ||
                    EF.Functions.Like(h.Description.ToLower(), searchTerm));
            }

            houses = sorting switch
            {
                HouseSorting.Price => houses.OrderBy(h => h.PricePerMonth),
                HouseSorting.NotRentedFirst => houses.OrderBy(h => h.RenterId),
                HouseSorting.Newest => houses.OrderByDescending(h => h.Id),
            };

            result.Houses = await houses
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(h => new HouseServiceModel()
                {
                    Address = h.Address,
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.ImageUrl != null,
                    Title = h.Title,
                })
                .ToListAsync();

            result.TotalHousesCount = await houses.CountAsync();

            return result;
        }

        public async Task<IEnumerable<HouseCategoryModel>> AllCategories()
        {
            return await repo.AllReadonly<Category>()
                .OrderBy(c => c.Name)
                .Select(c => new HouseCategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
            => await repo.AllReadonly<Category>().AnyAsync(c => c.Id == categoryId);


        public async Task<int> Create(HouseModel model, int agentId)
        {
            var house = new House()
            {
                Address = model.Address,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                Title = model.Title,
            };

            await repo.AddAsync(house);
            await repo.SaveChangesAsync();

            return house.Id;
        }

        public async Task<IEnumerable<HouseHomeModel>> GetLastThreeHouses()
        {
            return await repo.AllReadonly<House>()
                .OrderByDescending(h => h.Id)
                .Select(h => new HouseHomeModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl,
                })
                .Take(3)
                .ToListAsync();
        }
    }
}
