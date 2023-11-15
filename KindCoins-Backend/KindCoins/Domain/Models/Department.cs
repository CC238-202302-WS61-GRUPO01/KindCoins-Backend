using System.Text.Json.Serialization;

namespace KindCoins_Backend.KindCoins.Domain.Models;

public class Department
{
    public int Id { get; set; }
    public string DepartmentName { get; set; }
    //Relationships
    public int CountryId { get; set; }
    
    [JsonIgnore]
    public Country Country { get; set; }
    
    [JsonIgnore]
    public IList<District> Districts { get; set; } = new List<District>();
}