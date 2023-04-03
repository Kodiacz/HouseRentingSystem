using System.Collections.Immutable;

namespace HouseRentingSystem.Services.Services
{
    public class RentService : IRentService
    {
        private readonly HouseRentingDbContext dbContext;

        public RentService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<RentServiceModel> All()
        {
            return this.dbContext
                .Houses
                .Include(h => h.Agent.User)
                .Include(h => h.Renter)
                .Where(h => h.RenterId != null)
                .Select(h => new RentServiceModel()
                {
                    AgentEmail = h.Agent.User.Email,
                    AgentFullName = h.Agent.User.FirstName + " " + h.Agent.User.LastName,
                    HouseImageURL = h.ImageUrl,
                    HouseTitle = h.Title,
                    RenterEmail = h.Renter == null ? string.Empty : h.Renter.Email,
                    RenterFullName = h.Renter == null ? string.Empty : h.Renter.FirstName + " " + h.Renter.LastName,
                });
        }
    }
}
