namespace HouseRentingSystem.Services.Models.House
{
    public class HouseQueryServiceModel
    {
        public HouseQueryServiceModel()
        {
            this.Houses = new List<HouseServiceModel>();
        }

        public int TotalHousesCount { get; set; }

        public IEnumerable<HouseServiceModel> Houses { get; set; }
    }       
}
