namespace HouseRentingSystem.Services.Models.Agent
{
    public class BecomeAgentFormModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Display(Name = PhoneNumberDisplayName)]
        [Phone]
        public string PhoneNumber { get; init; } = null!;
    }
}
