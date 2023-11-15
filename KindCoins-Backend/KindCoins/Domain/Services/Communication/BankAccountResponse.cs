using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services.Communication;

public class BankAccountResponse : BaseResponse<BankAccount>
{
    public BankAccountResponse(BankAccount resource) : base(resource)
    {
    }

    public BankAccountResponse(string message) : base(message)
    {
    }
}