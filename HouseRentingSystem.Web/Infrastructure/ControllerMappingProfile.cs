namespace HouseRentingSystem.Web.Infrastructure
{
   public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            CreateMap<HouseDetailsServiceModel, HouseFormModel>();
            CreateMap<HouseFormModel, HouseDetailsServiceModel>();
        }
    }
}
