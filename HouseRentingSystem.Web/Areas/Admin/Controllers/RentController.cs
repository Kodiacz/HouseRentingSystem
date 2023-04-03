namespace HouseRentingSystem.Web.Areas.Admin.Controllers
{
    public class RentController : AdminController
    {
        private readonly IRentService rentService;

        public RentController(IRentService rentService)
        {
            this.rentService = rentService;
        }

        [Route("Rent/All")]
        public ActionResult All()
        {
            var rents = this.rentService.All();
            return View(rents);   
        }
    }
}
