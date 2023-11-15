using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services.Communication;

public class TypeOfCreditCardResponse: BaseResponse<TypeOfCreditCard>
{
    public TypeOfCreditCardResponse(TypeOfCreditCard resource) : base(resource)
    {
    }

    public TypeOfCreditCardResponse(string message) : base(message)
    {
    }
}