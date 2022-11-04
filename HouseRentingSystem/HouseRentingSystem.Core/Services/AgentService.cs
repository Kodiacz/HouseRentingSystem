namespace HouseRentingSystem.Core.Services
{
    using System.Threading.Tasks;

    using HouseRentingSystem.Core.Contracts;
    using HouseRentingSystem.Infrastructure.Data.Common;
    using HouseRentingSystem.Infrastructure.Data.Entities;

    using Microsoft.EntityFrameworkCore;

    public class AgentService : IAgentService
    {
        private readonly IRepository repo;

        public AgentService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task Create(string userId, string phoneNumber)
        {
            var agent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber,
            };

            await repo.AddAsync(agent);
            await repo.SaveChangesAsync();

        }

        public async Task<bool> ExistsById(string userId)
        {
            return await repo.All<Agent>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<bool> UserHasRents(string userId)
        {
            return await repo.All<House>()
               .AnyAsync(h => h.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await repo.All<Agent>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
