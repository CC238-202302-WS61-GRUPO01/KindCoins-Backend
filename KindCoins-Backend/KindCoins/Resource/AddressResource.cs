using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Resource;

public class AddressResource
{
    public int Id { get; set; }
    public string AddressName { get; set; }
    public string Reference { get; set; }
    public Campaign Campaign { get; set; }
    public District District { get; set; }
}