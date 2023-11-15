using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services.Communication;

public class SuscriptionPlanResponse : BaseResponse<SuscriptionPlan>
{
    public SuscriptionPlanResponse(SuscriptionPlan resource) : base(resource)
    {
    }

    public SuscriptionPlanResponse(string message) : base(message)
    {
    }
}