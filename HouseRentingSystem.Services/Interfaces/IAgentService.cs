namespace HouseRentingSystem.Services.Interfaces
{
    public interface IAgentService
    {
        bool ExistById(string userId);

        bool UserWithPhoneNumberExists(string phoneNumber);

        bool UserHasRents(string userId);

        void Create(string userId, string phoneNumber);
        int GetAgentId(string? userId);
    }
}
