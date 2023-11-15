using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services.Communication;

public class DepartmentResponse: BaseResponse<Department>
{
    public DepartmentResponse(Department resource) : base(resource)
    {
    }

    public DepartmentResponse(string message) : base(message)
    {
    }
}