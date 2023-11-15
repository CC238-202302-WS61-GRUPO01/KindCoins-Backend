using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services.Communication;

public class PaymentDataResponse: BaseResponse<PaymentData>
{
    public PaymentDataResponse(PaymentData resource) : base(resource)
    {
    }

    public PaymentDataResponse(string message) : base(message)
    {
    }
}