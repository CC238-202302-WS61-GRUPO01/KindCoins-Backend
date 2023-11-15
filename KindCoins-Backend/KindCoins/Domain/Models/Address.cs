using System.Text.Json.Serialization;

namespace KindCoins_Backend.KindCoins.Domain.Models;

public class Address
{
    public int Id { get; set; }
    public string AddressName { get; set; }

    public string Reference { get; set; }

    //Relationships
    public int CampaignId { get; set; }
    [JsonIgnore]
    public Campaign Campaign { get; set; }
    
    public int DistrictId { get; set; }
    [JsonIgnore]
    public District District { get; set; }
}