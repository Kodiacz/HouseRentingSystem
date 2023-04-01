using HouseRentingSystem.Infrastructure;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;
        private readonly IMapper mapper;

        public HouseController(
            IHouseService houseService, 
            IAgentService agentService, 
            IMapper mapper)
        {
            this.houseService = houseService;
            this.agentService = agentService;
            this.mapper = mapper;
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
            IEnumerable<HouseServiceModel> myHouses = null;

            var userId = this.User.Id();

            if (this.agentService.ExistById(userId!))
            {
                var currentAgentId = this.agentService.GetAgentId(userId);

                myHouses = this.houseService.AllHousesByAgentId(currentAgentId);
            }
            else
            {
                myHouses = this.houseService.AllHousesByUserId(userId!);
            }
            
            return View(myHouses);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details(int id, string information)
        {
            if (!this.houseService.Exists(id))
            {
                //ViewData[ErrorMessage] = "This house dose not exist in the system";

                //return RedirectToAction(nameof(HomeController.Index), "Home");

                return BadRequest();
            }

            var houseModel = this.houseService.HouseDetailsById(id);

            if (information != houseModel.GetInforamtion())
            {
                return BadRequest();
            }

            return View(houseModel); 
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

            return RedirectToAction(nameof(Details), new { id = newHouseId, information = houseModel.GetInforamtion() });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!this.houseService.Exists(id))
            {
                //ViewData[ErrorMessage] = "That house was not found in the system";

                //return RedirectToAction(nameof(HomeController.Index), "Home");

                return BadRequest();
            }

            if (!this.houseService.HasAgentWithId(id, this.User.Id()!) &&
                 !this.User.IsAdmin())
            {
                //ViewData[ErrorMessage] = "You are not authorize to do that";

                //return RedirectToAction(nameof(HomeController.Index), "Home");

                return Unauthorized();
            }

            var house = this.houseService.HouseDetailsById(id);

            var houseCategoryId = this.houseService.GetHouseCategoryId(house.Id);

            var houseModel = this.mapper.Map<HouseFormModel>(house);
            houseModel.CategoryId = houseCategoryId;
            houseModel.Categories = this.houseService.AllCategories();

            return View(houseModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, HouseFormModel model)
        {
            if (!this.houseService.Exists(id))
            {
                //ViewData[ErrorMessage] = "That house was not found in the system";

                //return RedirectToAction(nameof(HomeController.Index), "Home");

                return BadRequest();
            }

            if (!this.houseService.HasAgentWithId(id, this.User!.Id()!) &&
                !this.User.IsAdmin())
            {
                //ViewData[ErrorMessage] = "You are not authorize to do that";

                //return RedirectToAction(nameof(HomeController.Index), "Home");

                return Unauthorized();
            }

            if (!this.houseService.CategoryExists(model.CategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = this.houseService.AllCategories();

                return View(model);
            }

            this.houseService.Edit(id, model.Title, model.Address, model.Description,
                model.ImageUrl, model.PricePerMonth, model.CategoryId);

            return RedirectToAction(nameof(Details), new { id = id, inforamtion = model.GetInforamtion() });
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
            if (!this.houseService.Exists(id))
            {
                //ViewData[ErrorMessage] = "That house was not found in the system";

                //return RedirectToAction(nameof(HomeController.Index), "Home");

                return BadRequest();
            }

            if (!this.agentService.ExistById(this.User.Id()!) && 
                !this.User.IsAdmin())
            {
                //ViewData[ErrorMessage] = "You are not authorize to do that";

                //return RedirectToAction(nameof(HomeController.Index), "Home");

                return Unauthorized();
            }

            if (this.houseService.IsRented(id))
            {
                //ViewData[ErrorMessage] = "This house is already rented by someone else";

                //return RedirectToAction(nameof(HomeController.Index), "Home");

                return BadRequest();
            }

            this.houseService.Rent(id, this.User.Id()!);

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public IActionResult Leave(int id)
        {
            if (!this.houseService.Exists(id) ||
                !this.houseService.IsRented(id))
            {
                //ViewData[ErrorMessage] = "Bad Request";

                //return RedirectToAction(nameof(HomeController.Index), "Home");

                return BadRequest();
            }

            if (!this.houseService.IsRentedByUserWithId(id, this.User.Id()!))
            {
                //ViewData[ErrorMessage] = "You are not authorize to do that";

                //return RedirectToAction(nameof(HomeController.Index), "Home");

                return Unauthorized();
            }

            this.houseService.Leave(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
