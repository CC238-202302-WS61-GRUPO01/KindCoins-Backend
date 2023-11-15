using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services.Communication;

public class UserResponse : BaseResponse<User>
{
    public UserResponse(User resource) : base(resource)
    {
    }

    public UserResponse(string message) : base(message)
    {
    }
}