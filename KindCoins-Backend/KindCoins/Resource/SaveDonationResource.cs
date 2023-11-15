namespace KindCoins_Backend.KindCoins.Resource;

public class SaveDonationResource
{
    public decimal? Amount { get; set; }
    public int TypeOfDonationId { get; set; }
    public int CampaignId { get; set; }
    public int UserId { get; set; }
}