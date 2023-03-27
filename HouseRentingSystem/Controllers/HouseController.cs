using HouseRentingSystem.Infrastructure;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;

        public HouseController(IHouseService houseService, IAgentService agentService)
        {
            this.houseService = houseService;
            this.agentService = agentService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult All([FromQuery] AllHousesQueryModel query)
        {
            var queryResult = this.houseService.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllHousesQueryModel.HousesPerPage);

            query.TotalHousesCount = queryResult.TotalHousesCount;
            query.Houses = queryResult.Houses;

            var houseCategories = this.houseService.AllCategoriesNames();
            query.Categories = houseCategories;

            return View(query);
        }

        [HttpGet]
        public IActionResult Mine()
        {
            return View(new AllHousesQueryModel());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(new HouseDetailsViewModel());
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            if (!this.agentService.ExistById(this.User.Id()!))
            {
                ViewData[ErrorMessage] = "First you have to become an agent";

                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            return View(new HouseFormModel()
            {
                Categories = this.houseService.AllCategories(),
            });
        }

        [HttpPost]
        public IActionResult Add(HouseFormModel houseModel)
        {
            if (!this.agentService.ExistById(this.User.Id()!))
            {
                ViewData[ErrorMessage] = "First you have to become an agent";

                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            if (!this.houseService.CategoryExists(houseModel.CategoryId))
            {
                this.ModelState.AddModelError(nameof(houseModel.CategoryId),
                    "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                houseModel.Categories = this.houseService.AllCategories();

                return View(houseModel);
            }

            var agentId = this.agentService.GetAgentId(this.User.Id());

            var newHouseId = this.houseService.Create(houseModel, agentId);

            return RedirectToAction(nameof(Details), new { id = newHouseId });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(new HouseFormModel());
        }

        [HttpPost]
        public IActionResult Edit(int id, HouseFormModel house)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View(new HouseDetailsViewModel());
        }

        [HttpPost]
        public IActionResult Delete(HouseDetailsViewModel house)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
        }

        [HttpPost]
        public IActionResult Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public IActionResult Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
