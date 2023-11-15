using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services;

public interface IDistrictService
{
    Task<IEnumerable<District>> ListAsync();
    Task<DistrictResponse> SaveAsync(District district);
    Task<DistrictResponse> UpdateAsync(int id, District district);
    Task<DistrictResponse> DeleteAsync(int id);
    Task<District> GetByIdAsync(int id);
}