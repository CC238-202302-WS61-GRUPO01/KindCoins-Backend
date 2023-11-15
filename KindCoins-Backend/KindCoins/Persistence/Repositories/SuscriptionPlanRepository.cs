using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.Shared.Persistence.Contexts;
using KindCoins_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.KindCoins.Persistence.Repositories;

public class SuscriptionPlanRepository : BaseRepository, ISuscriptionPlanRepository
{
    public SuscriptionPlanRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<SuscriptionPlan>> ListAsync()
    {
        return await _context.SuscriptionPlans.ToListAsync();
    }
    
    public async Task AddAsync(SuscriptionPlan suscriptionPlan)
    {
        await _context.SuscriptionPlans.AddAsync(suscriptionPlan);
    }
    
    public async Task<SuscriptionPlan> FindByIdAsync(int id)
    {
        return await _context.SuscriptionPlans
            .FindAsync(id);;
    }
    
    public async Task<SuscriptionPlan> FindByPlanAsync(string plan)
    {
        return await _context.SuscriptionPlans
            .FirstOrDefaultAsync(p => p.Plan == plan);
    }
    
    public void Update(SuscriptionPlan suscriptionPlan)
    {
        _context.SuscriptionPlans.Update(suscriptionPlan);
    }
    
    public void Remove(SuscriptionPlan suscriptionPlan)
    {
        _context.SuscriptionPlans.Remove(suscriptionPlan);
    }
    
}