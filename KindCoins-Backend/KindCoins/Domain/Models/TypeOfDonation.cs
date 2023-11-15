using System.Collections;
using System.Text.Json.Serialization;

namespace KindCoins_Backend.KindCoins.Domain.Models;

public class TypeOfDonation
{
    public int Id {get;set;}
    public string TypeDonation {get; set;}
    //Relationships
    [JsonIgnore]
    public IList<Campaign> Campaigns { get; set; } = new List<Campaign>();

    [JsonIgnore] public IList<Donation> Donations { get; set; } = new List<Donation>();
}