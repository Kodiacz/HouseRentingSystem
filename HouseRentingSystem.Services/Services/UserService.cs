namespace HouseRentingSystem.Services
{
    public class UserService : IUserService
    {
        private readonly HouseRentingDbContext dbContext;

        public UserService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string? UserFullName(string userId)
        {
            var user = this.dbContext.Users.Find(userId);

            if (string.IsNullOrEmpty(user.FirstName) || 
                string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }

            return user.FirstName + " " + user.LastName;
        }
    }
}
