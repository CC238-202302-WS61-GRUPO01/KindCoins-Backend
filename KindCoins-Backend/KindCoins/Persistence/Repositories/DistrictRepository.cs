using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.Shared.Persistence.Contexts;
using KindCoins_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.KindCoins.Persistence.Repositories;

public class DistrictRepository: BaseRepository, IDistrictRepository
{
    public DistrictRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<District>> ListAsync()
    {
        return await _context.Districts
            .Include(p=>p.Department)
            .ToListAsync();
    }
    public async Task AddAsync(District district)
    {
        await _context.Districts.AddAsync(district);
    }
    public async Task<District> FindByIdAsync(int districtId)
    {
        return await _context.Districts
            .Include(p=>p.Department)
            .FirstOrDefaultAsync(p => p.Id == districtId);
    }
    
    public async Task<IEnumerable<District>> FindByDepartmentIdAsync(int departmentId)
    {
        return await _context.Districts
            .Where(p => p.DepartmentId == departmentId)
            .Include(p=>p.Department)
            .ToListAsync();
    }
    
    public async Task<District> FindByNameAsync(string districtName)
    {
        return await _context.Districts
            .Include(p=>p.Department)
            .FirstOrDefaultAsync(p => p.DistrictName == districtName);
    }

    public void Update(District district)
    {
        _context.Districts.Update(district);
    }

    public void Remove(District district)
    {
        _context.Districts.Remove(district);
    }
}