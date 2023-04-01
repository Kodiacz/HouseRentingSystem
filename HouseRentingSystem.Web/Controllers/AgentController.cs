using HouseRentingSystem.Constants;
using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Services.Models.Agent;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;
        //private readonly string? userId;

        public AgentController(IAgentService agentService)
        {
            this.agentService = agentService;
            //this.userId = this.User.Id();
        }

        [HttpGet]
        public IActionResult Become()
        {
            if (this.agentService.ExistById(this.User.Id()!)) 
            {
                TempData[ErrorMessage] = "You are already an agent";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Become(BecomeAgentFormModel model)
        {
            var userId = this.User.Id();


            if (this.agentService.ExistById(userId!))
            {
                return BadRequest();
            }

            if (this.agentService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                ModelState.AddModelError("Error", "Phone number already exists. Enter another one.");
            }

            if (this.agentService.UserHasRents(userId!))
            {
                ModelState.AddModelError("Error", "You should have no rent to become and agent!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.agentService.Create(userId, model.PhoneNumber);

            return RedirectToAction(nameof(HouseController.All), "House");
        }
    }
}
