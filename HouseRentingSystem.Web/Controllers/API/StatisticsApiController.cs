namespace HouseRentingSystem.Controllers.API
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsApiController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet]
        public StatisticsServiceModel GetStatistics()
        {
            return this.statisticsService.Total();
        }
    }
}
