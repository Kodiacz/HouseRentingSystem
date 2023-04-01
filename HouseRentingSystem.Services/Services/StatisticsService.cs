namespace HouseRentingSystem.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly HouseRentingDbContext dbContext;

        public StatisticsService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public StatisticsServiceModel Total()
        {
            var totalHouses = this.dbContext
                .Houses
                .Where(h => !h.IsDeleted)
                .Count();

            var totalRents = this.dbContext
                .Houses
                .Where(h => h.RenterId != null && !h.IsDeleted)
                .Count();

            return new StatisticsServiceModel()
            {
                TotalHouses = totalHouses,
                TotalRents = totalRents,
            };
        }
    }
}
