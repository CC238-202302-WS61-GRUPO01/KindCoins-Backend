using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services.Communication;

public class CountryResponse: BaseResponse<Country>
{
    public CountryResponse(Country resource) : base(resource)
    {
    }

    public CountryResponse(string message) : base(message)
    {
    }
}