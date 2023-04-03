namespace HouseRentingSystem.Web.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("Users/All")]
        public IActionResult All()
        {
            var users = this.userService.All();
            return View(users);
        }
    }
}
