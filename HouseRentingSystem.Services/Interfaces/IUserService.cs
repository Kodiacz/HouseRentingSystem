namespace HouseRentingSystem.Services.Interfaces
{
    public interface IUserService
    {
        string UserFullName(string userId);

        IEnumerable<UserServiceModel> All();
    }
}
