using HouseRentingSystem.Services.Models.Rent;
using Microsoft.Extensions.Caching.Memory;

namespace HouseRentingSystem.Web.Areas.Admin.Controllers
{
    public class RentController : AdminController
    {
        private readonly IRentService rentService;
        private readonly IMemoryCache memoryCache;

        public RentController(IRentService rentService, IMemoryCache memoryCache)
        {
            this.rentService = rentService;
            this.memoryCache = memoryCache;
        }

        [Route("Rent/All")]
        public ActionResult All()
        {
            var rents = this.memoryCache.Get<IEnumerable<RentServiceModel>>(RentsCacheKey);

            if (rents == null)
            {
                rents = this.rentService.All();

                var cacheOpitons = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(5));

                this.memoryCache.Set(RentsCacheKey, rents, cacheOpitons);
            }

            return View(rents);
        }
    }
}
