namespace HouseRentingSystem.Core.Contracts
{
    using HouseRentingSystem.Core.Models.House;

    public interface IHouseService
    {
        Task<IEnumerable<HouseHomeModel>> GetLastThreeHouses();

        Task<IEnumerable<HouseHomeModel>> AllCategories();
    }
}
