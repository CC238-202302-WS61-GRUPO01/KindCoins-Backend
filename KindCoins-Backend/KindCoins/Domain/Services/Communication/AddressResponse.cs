using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services.Communication;

public class AddressResponse: BaseResponse<Address>
{
    public AddressResponse(Address resource) : base(resource)
    {
    }

    public AddressResponse(string message) : base(message)
    {
    }
}