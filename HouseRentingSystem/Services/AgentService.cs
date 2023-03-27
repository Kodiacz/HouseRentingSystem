namespace HouseRentingSystem.Services
{
    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext dbContext;

        public AgentService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(string userId, string phoneNumber)
        {
            var agent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber,
            };

            this.dbContext.Agents.Add(agent);
            this.dbContext.SaveChanges();
        }

        public bool ExistById(string userId)
        {
            return this.dbContext
                .Agents.Any(a => a.UserId == userId);
        }

        public int GetAgentId(string? userId)
        {
            return this.dbContext
                .Agents
                .FirstOrDefault(a => a.UserId == userId)!
                .Id;
        }

        public bool UserHasRents(string userId)
        {
            return this.dbContext.Houses.Any(h => h.RenterId == userId);
        }

        public bool UserWithPhoneNumberExists(string phoneNumber)
        {
            return this.dbContext.Agents.Any(a => a.PhoneNumber == phoneNumber);
        }
    }
}
