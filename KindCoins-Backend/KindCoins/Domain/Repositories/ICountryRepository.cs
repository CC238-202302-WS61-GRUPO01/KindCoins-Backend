using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> ListAsync();
    Task AddAsync(Country country);
    Task<Country> FindByIdAsync(int countryId);
    void Update(Country country);
    void Remove(Country country);
    
    Task<Country> FindByNameAsync(string countryName);
}