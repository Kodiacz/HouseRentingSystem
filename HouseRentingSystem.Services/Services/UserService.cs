namespace HouseRentingSystem.Services
{
    public class UserService : IUserService
    {
        private readonly HouseRentingDbContext dbContext;

        public UserService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<UserServiceModel> All()
        {
            var allUsers = new List<UserServiceModel>();

            var agents = this.dbContext
                .Agents
                .Include(ag => ag.User)
                .Select(ag => new UserServiceModel()
                {
                    Email = ag.User.Email,
                    FullName = ag.User.FirstName + " " + ag.User.LastName,
                    PhoneNumber = ag.PhoneNumber,
                });

            allUsers.AddRange(agents);

            var users = this.dbContext
                .Users
                .Where(u => !this.dbContext.Agents.Any(ag => ag.UserId == u.Id))
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName,
                });

            allUsers.AddRange(users);
            
            return allUsers;
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
