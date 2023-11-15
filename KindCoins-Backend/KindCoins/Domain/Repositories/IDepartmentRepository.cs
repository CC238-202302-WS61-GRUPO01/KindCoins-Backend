using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> ListAsync();
    Task AddAsync(Department department);
    Task<Department> FindByIdAsync(int departmentId);
    Task<IEnumerable<Department>> FindByCountryIdAsync(int countryId);
    Task<Department> FindByNameAsync(string departmentName);
    void Update(Department department);
    void Remove(Department department);
}