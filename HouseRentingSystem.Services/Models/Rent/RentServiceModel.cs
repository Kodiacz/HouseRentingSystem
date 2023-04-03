namespace HouseRentingSystem.Services.Models.Rent
{
    public class RentServiceModel
    {
        public string HouseTitle { get; init; } = null!;

        public string HouseImageURL { get; init; } = null!;

        public string AgentFullName { get; init; } = null!;

        public string AgentEmail { get; init; } = null!;

        public string? RenterFullName { get; init; } 

        public string? RenterEmail { get; init; }
    }
}
