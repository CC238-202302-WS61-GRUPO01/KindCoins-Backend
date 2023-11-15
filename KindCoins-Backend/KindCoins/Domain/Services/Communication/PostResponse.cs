using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services.Communication;

public class PostResponse: BaseResponse<Post>
{
    public PostResponse(Post resource) : base(resource)
    {
    }

    public PostResponse(string message) : base(message)
    {
    }
}