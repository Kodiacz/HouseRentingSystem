// IT'S IMPORTANT TO BE IN THIS NAMESPACE!!!
namespace Microsoft.Extensions.DependencyInjection
{
    using HouseRentingSystem.Core.Contracts;
    using HouseRentingSystem.Core.Services;
    using HouseRentingSystem.Infrastructure.Data.Common;

    public static class HouseRentingServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IHouseService, HouseService>();

            return services;
        }
    }
}
