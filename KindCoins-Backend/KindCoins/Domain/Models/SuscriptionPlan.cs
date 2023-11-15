using System.Text.Json.Serialization;

namespace KindCoins_Backend.KindCoins.Domain.Models;

public class SuscriptionPlan
{
    public int Id { get; set; }
    public string Plan { get; set; }
    //Relationships
    [JsonIgnore]
    public IList<User> Users { get; set; } = new List<User>();
}