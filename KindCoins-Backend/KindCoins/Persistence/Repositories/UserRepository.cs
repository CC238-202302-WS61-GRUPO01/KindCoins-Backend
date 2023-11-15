using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.Shared.Persistence.Contexts;
using KindCoins_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.KindCoins.Persistence.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users
            .Include(p => p.SuscriptionPlan)
            .ToListAsync();
    }
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }
    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.Users
            .Include(p => p.SuscriptionPlan)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }
    
    public async Task<User> FindByEmailAsync(string email)
    {
        return await _context.Users
            .Include(p => p.SuscriptionPlan)
            .FirstOrDefaultAsync(p => p.Email == email);
    }
    
    public async Task<User> FindByDniAsync(string dni)
    {
        return await _context.Users
            .Include(p => p.SuscriptionPlan)
            .FirstOrDefaultAsync(p => p.DNI == dni);
    }
}