namespace HouseRentingSystem.Web.Areas.Admin.Controllers
{
    public class HouseController : AdminController
    {
        private readonly IHouseService  houseService;
        private readonly IAgentService agentService;

        public HouseController(
            IAgentService agentService, 
            IHouseService houseService)
        {
            this.houseService = houseService;
            this.agentService = agentService;
        }

        public IActionResult Mine()
        {
            var myHouses = new MyHouseViewModel();

            var adminUserId = this.User.Id();
            myHouses.RentedHouses = this.houseService.AllHousesByUserId(adminUserId!);

            var adminAgentId = this.agentService.GetAgentId(adminUserId);
            myHouses.AddedHouses = this.houseService.AllHousesByAgentId(adminAgentId!);

            return View(myHouses);
        }
    }
}
