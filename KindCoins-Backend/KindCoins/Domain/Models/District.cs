using System.Text.Json.Serialization;

namespace KindCoins_Backend.KindCoins.Domain.Models;

public class District
{
    public int Id { get; set; }
    public string DistrictName { get; set; }
    //Relationships
    public int DepartmentId { get; set; }
    [JsonIgnore]
    public Department Department { get; set; }
    
    [JsonIgnore]
    public IList<Address> Addresses { get; set; } = new List<Address>();
}