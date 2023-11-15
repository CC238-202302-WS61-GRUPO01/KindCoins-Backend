using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.Shared.Persistence.Contexts;
using KindCoins_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.KindCoins.Persistence.Repositories;

public class DepartmentRepository: BaseRepository, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Department>> ListAsync()
    {
        return await _context.Departments
            .Include(p=>p.Country)
            .ToListAsync();
    }
    public async Task AddAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
    }
    public async Task<Department> FindByIdAsync(int departmentId)
    {
        return await _context.Departments
            .Include(p=>p.Country)
            .FirstOrDefaultAsync(p => p.Id == departmentId);
    }
    
    public async Task<IEnumerable<Department>> FindByCountryIdAsync(int countryId)
    {
        return await _context.Departments
            .Where(p => p.CountryId == countryId)
            .Include(p=>p.Country)
            .ToListAsync();
    }
    
    public async Task<Department> FindByNameAsync(string departmentName)
    {
        return await _context.Departments
            .FirstOrDefaultAsync(p => p.DepartmentName == departmentName);
    }

    public void Update(Department department)
    {
        _context.Departments.Update(department);
    }

    public void Remove(Department department)
    {
        _context.Departments.Remove(department);
    }
}