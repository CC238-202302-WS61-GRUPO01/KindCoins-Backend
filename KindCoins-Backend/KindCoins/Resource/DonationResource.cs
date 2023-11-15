using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Resource;

public class DonationResource
{
    public int Id { get; set; }
    public decimal? Amount { get; set; }
    public TypeOfDonation TypeOfDonation { get; set; }
    public Campaign Campaign { get; set; }
    public User User { get; set; }
}