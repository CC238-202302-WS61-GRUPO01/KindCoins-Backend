using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services.Communication;

public class DistrictResponse: BaseResponse<District>
{
    public DistrictResponse(District resource) : base(resource)
    {
    }

    public DistrictResponse(string message) : base(message)
    {
    }
}