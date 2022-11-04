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

        public async Task<bool> ExistsById(string userId)
        {
            return await repo.All<Agent>()
                .AnyAsync(a => a.UserId == userId);
        }
    }
}
