using System.Text.Json.Serialization;
using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Resource;

public class CampaignResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slogan { get; set; }
    public string HeaderPhoto { get; set; }
    public string AditionalPhoto { get; set; }
    public string Description { get; set; }
    public int Goal { get; set; }
    public User User { get; set; }
    public TypeOfDonation TypeOfDonation { get; set; }
    
}