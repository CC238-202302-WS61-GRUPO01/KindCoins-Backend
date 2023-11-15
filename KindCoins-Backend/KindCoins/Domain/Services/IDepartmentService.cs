using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> ListAsync();
    Task<DepartmentResponse> SaveAsync(Department department);
    Task<DepartmentResponse> UpdateAsync(int id, Department department);
    Task<DepartmentResponse> DeleteAsync(int id);
    Task<Department> GetByIdAsync(int id);
}