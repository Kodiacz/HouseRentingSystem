namespace HouseRentingSystem.Controllers
{
    using HouseRentingSystem.Core.Contracts;
    using HouseRentingSystem.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IHouseService houseService;

        public HomeController(IHouseService _houseService)
        {
            this.houseService = _houseService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await houseService.GetLastThreeHouses();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}