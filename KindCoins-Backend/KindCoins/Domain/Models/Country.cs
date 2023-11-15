using System.Text.Json.Serialization;

namespace KindCoins_Backend.KindCoins.Domain.Models;

public class Country
{
    public int Id { get; set; }
    public string CountryName { get; set; }
    //Relationships
    [JsonIgnore]
    public IList<Department> Departments { get; set; } = new List<Department>();
}