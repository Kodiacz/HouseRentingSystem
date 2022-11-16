namespace HouseRentingSystem.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using HouseRentingSystem.Core.Contracts;
    using HouseRentingSystem.Core.Models.House;
    using HouseRentingSystem.Extensions;
    using HouseRentingSystem.Core.Models;

    [Authorize]
    public class HouseController : Controller
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;


        public HouseController(
            IAgentService _agentService,
            IHouseService _houseService)
        {
            this.agentService = _agentService;
            this.houseService = _houseService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllHousesQueryModel query)
        {
            var result = await houseService.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllHousesQueryModel.HousesPerPage);

            query.TotalHousesCount = result.TotalHousesCount;
            query.Categories = await houseService.AllCategoriesNames();
            query.Houses = result.Houses;

            return View(query);

            var model = new HousesQueryModel();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = new HousesQueryModel();

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var model = new HouseDetailsModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if ((await agentService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            var model = new HouseModel()
            {
                Categories = await this.houseService.AllCategories(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseModel model)
        {
            if ((await agentService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            if ((await this.houseService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await this.houseService.AllCategories();

                return View(model);
            }

            int agentId = await this.agentService.GetAgentId(User.Id());

            int id = await this.houseService.Create(model, agentId);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new HouseModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HouseModel model)
        {
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
