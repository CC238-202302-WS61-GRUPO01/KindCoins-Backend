namespace KindCoins_Backend.KindCoins.Resource;

public class SaveCampaignResource
{
    public string Name { get; set; }
    public string Slogan { get; set; }
    public string HeaderPhoto { get; set; }
    public string AditionalPhoto { get; set; }
    public string Description { get; set; }
    public int Goal { get; set; }
    public int UserId { get; set; }
    public int TypeOfDonationId { get; set; }
}