namespace HouseRentingSystem.Controllers
{
    using HouseRentingSystem.Core.Models.Agent;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AgentController : Controller
    {
        [HttpGet]
        public IActionResult Become()
        {
            return View();
        }

        public async Task<IActionResult> Bevome(BecomeAgentModel model)
        {
            return RedirectToAction("All", "House");
        }
    }
}
