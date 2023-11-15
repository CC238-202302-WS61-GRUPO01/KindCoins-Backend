using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services;

public interface ICountryService
{
    Task<IEnumerable<Country>> ListAsync();
    Task<CountryResponse> SaveAsync(Country country);
    Task<CountryResponse> UpdateAsync(int id, Country country);
    Task<CountryResponse> DeleteAsync(int id);
    Task<Country> GetByIdAsync(int id);
}