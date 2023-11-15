namespace KindCoins_Backend.KindCoins.Domain.Models;

public class BankAccount
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    //Relationships
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; }
}