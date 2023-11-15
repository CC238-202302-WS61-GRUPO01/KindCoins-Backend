using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services;

public interface ISuscriptionPlanService
{
    Task<IEnumerable<SuscriptionPlan>> ListAsync();
    Task<SuscriptionPlanResponse> SaveAsync(SuscriptionPlan suscriptionPlan);
    Task<SuscriptionPlanResponse> UpdateAsync(int id, SuscriptionPlan suscriptionPlan);
    Task<SuscriptionPlanResponse> DeleteAsync(int id);
    Task<SuscriptionPlan> GetByIdAsync(int id);
}