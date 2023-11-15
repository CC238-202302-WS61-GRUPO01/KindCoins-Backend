using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Resource;

public class BankAccountResource
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public CampaignResource Campaign { get; set; }
}