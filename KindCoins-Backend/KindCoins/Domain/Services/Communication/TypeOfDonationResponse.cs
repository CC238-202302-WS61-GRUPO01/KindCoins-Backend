using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services.Communication;

public class TypeOfDonationResponse : BaseResponse<TypeOfDonation>
{
    public TypeOfDonationResponse(TypeOfDonation resource) : base(resource)
    {
    }

    public TypeOfDonationResponse(string message) : base(message)
    {
    }
}