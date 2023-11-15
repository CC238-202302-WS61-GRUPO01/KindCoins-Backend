using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.Shared.Persistence.Contexts;

namespace KindCoins_Backend.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}