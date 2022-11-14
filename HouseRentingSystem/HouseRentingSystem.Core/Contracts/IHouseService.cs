namespace HouseRentingSystem.Core.Contracts
{
    using HouseRentingSystem.Core.Models.House;

    public interface IHouseService
    {
        Task<IEnumerable<HouseHomeModel>> GetLastThreeHouses();

        Task<IEnumerable<HouseCategoryModel>> AllCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<int> Create(HouseModel model, int agentId);
    }
}
