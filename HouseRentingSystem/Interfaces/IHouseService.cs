namespace HouseRentingSystem.Interfaces
{
    public interface IHouseService
    {
        IEnumerable<HouseIndexServiceModel> LastThreeHouses();

        IEnumerable<HouseCategoryServiceModel> AllCategories();

        bool CategoryExists(int categoryId);

        int Create(HouseFormModel houseModel, int agentId);

        HouseQueryServiceModel All(
            string? category = null,
            string? searchTerm = null,
            HouseSorting sorting = HouseSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1);

        IEnumerable<string> AllCategoriesNames();
    }
}
