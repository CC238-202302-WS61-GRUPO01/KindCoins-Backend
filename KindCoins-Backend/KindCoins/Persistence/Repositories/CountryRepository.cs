using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.Shared.Persistence.Contexts;
using KindCoins_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.KindCoins.Persistence.Repositories;

public class CountryRepository: BaseRepository, ICountryRepository
{
    public CountryRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Country>> ListAsync()
    {
        return await _context.Countries
            .ToListAsync();
    }
    
    public async Task AddAsync(Country country)
    {
        await _context.Countries.AddAsync(country);
    }

    public async Task<Country> FindByIdAsync(int countryId)
    {
        return await _context.Countries
            .FirstOrDefaultAsync(p => p.Id == countryId);
    }
    
    public async Task<Country> FindByNameAsync(string countryName)
    {
        return await _context.Countries
            .FirstOrDefaultAsync(p => p.CountryName == countryName);
    }

    public void Update(Country country)
    {
        _context.Countries.Update(country);
    }

    public void Remove(Country country)
    {
        _context.Countries.Remove(country);
    }
}