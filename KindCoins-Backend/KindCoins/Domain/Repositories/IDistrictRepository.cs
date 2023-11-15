using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface IDistrictRepository
{
    Task<IEnumerable<District>> ListAsync();
    Task AddAsync(District district);
    Task<District> FindByIdAsync(int districtId);
    Task<IEnumerable<District>> FindByDepartmentIdAsync(int departmentId);
    Task<District> FindByNameAsync(string districtName);
    void Update(District district);
    void Remove(District district);
}