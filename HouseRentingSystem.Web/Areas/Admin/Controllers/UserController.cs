using HouseRentingSystem.Services.Models.User;
using Microsoft.Extensions.Caching.Memory;

namespace HouseRentingSystem.Web.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache cache;

        public UserController(IUserService userService, IMemoryCache cache)
        {
            this.userService = userService;
            this.cache = cache;
        }

        [Route("Users/All")]
        public IActionResult All()
        {
            var users = this.cache
                .Get<IEnumerable<UserServiceModel>>(UsersCacheKey);

            if (users == null)
            {
                users = this.userService.All();

                var cacheOpetions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                this.cache.Set(UsersCacheKey, users, cacheOpetions);
            }

            return View(users);
        }
    }
}
