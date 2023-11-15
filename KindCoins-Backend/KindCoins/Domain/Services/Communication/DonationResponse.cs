using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services.Communication;

public class DonationResponse: BaseResponse<Donation>
{
    public DonationResponse(Donation resource) : base(resource)
    {
    }

    public DonationResponse(string message) : base(message)
    {
    }
}