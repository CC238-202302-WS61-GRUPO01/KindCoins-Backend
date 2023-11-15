using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface ISuscriptionPlanRepository
{
    Task<IEnumerable<SuscriptionPlan>> ListAsync();
    Task AddAsync(SuscriptionPlan suscriptionPlan);
    Task<SuscriptionPlan> FindByIdAsync(int id);
    Task<SuscriptionPlan> FindByPlanAsync(string plan);
    void Update(SuscriptionPlan suscriptionPlan);
    void Remove(SuscriptionPlan suscriptionPlan);
}