namespace HouseRentingSystem.Models.House
{
    public class HouseDetailsServiceModel : HouseServiceModel
    {
        public string Description { get; init; }

        public string Category { get; init; }

        public AgentServiceModel Agent { get; init; }
    }
}
