namespace KindCoins_Backend.KindCoins.Domain.Models;

public class Donation
{
    public int Id { get; set; }
    public decimal? Amount { get; set; }
    public int TypeOfDonationId { get; set; }
    public TypeOfDonation TypeOfDonation { get; set; }
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}