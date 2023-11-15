using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services.Communication;

public class CampaignResponse: BaseResponse<Campaign>
{
    public CampaignResponse(Campaign resource) : base(resource)
    {
    }

    public CampaignResponse(string message) : base(message)
    {
    }
}