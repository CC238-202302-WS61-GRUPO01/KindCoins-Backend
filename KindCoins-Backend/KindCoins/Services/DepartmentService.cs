using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public async Task<IEnumerable<Department>> ListAsync()
    {
        return await _departmentRepository.ListAsync();
    }
    
    public DepartmentService(IDepartmentRepository departmentRepository,ICountryRepository countryRepository, IUnitOfWork unitOfWork)
    {
        _departmentRepository = departmentRepository;
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Department> GetByIdAsync(int id)
    {
        return await _departmentRepository.FindByIdAsync(id);
    }

    public async Task<DepartmentResponse> SaveAsync(Department department)
    {
        //Validate if the department exists
        var existingDepartment = await _departmentRepository.FindByNameAsync(department.DepartmentName);
        if (existingDepartment != null)
            return new DepartmentResponse("Department already exists.");
        //Validate if the country exists
        var existingCountry = await _countryRepository.FindByIdAsync(department.CountryId);
        if (existingCountry == null)
            return new DepartmentResponse("Invalid country.");
        
        try
        {
            await _departmentRepository.AddAsync(department);
            await _unitOfWork.CompleteAsync();

            return new DepartmentResponse(department);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new DepartmentResponse($"An error occurred when saving the department: {ex.Message}");
        }
    }

    public async Task<DepartmentResponse> UpdateAsync(int id, Department department)
    {
        var existingDepartment = await _departmentRepository.FindByIdAsync(id);
        if (existingDepartment == null) return new DepartmentResponse("Department not found");

        existingDepartment.DepartmentName = department.DepartmentName;
        
        try
        {
            _departmentRepository.Update(existingDepartment);
            await _unitOfWork.CompleteAsync();

            return new DepartmentResponse(existingDepartment);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new DepartmentResponse($"An error occurred when updating the department: {ex.Message}");
        }
    }

    public async Task<DepartmentResponse> DeleteAsync(int id)
    {
        var existingDepartment = await _departmentRepository.FindByIdAsync(id);
        if (existingDepartment == null) return new DepartmentResponse("Department not found");
        try
        {
            _departmentRepository.Remove(existingDepartment);
            await _unitOfWork.CompleteAsync();

            return new DepartmentResponse(existingDepartment);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new DepartmentResponse($"An error occurred when deleting the department: {ex.Message}");
        }
    }
}