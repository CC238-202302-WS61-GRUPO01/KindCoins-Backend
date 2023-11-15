using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Resource;

public class DistrictResource
{
    public int Id { get; set; }
    public string DistrictName { get; set; }
    public Department Department { get; set; }
}