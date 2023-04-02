namespace HouseRentingSystem.Web.Areas.Admin.Models
{
    public class MyHouseViewModel
    {
        public MyHouseViewModel()
        {
            this.AddedHouses = new List<HouseServiceModel>();
            this.RentedHouses = new List<HouseServiceModel>();
        }

        public IEnumerable<HouseServiceModel> AddedHouses { get; set; }

        public IEnumerable<HouseServiceModel> RentedHouses { get; set; }
    }
}
