using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class DistrictService : IDistrictService
{
     private readonly IDistrictRepository _districtRepository;
     private readonly IDepartmentRepository _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DistrictService(IDistrictRepository districtRepository,IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
    {
        _districtRepository = districtRepository;
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<District>> ListAsync()
    {
        return await _districtRepository.ListAsync();
    }
    
    public async Task<District> GetByIdAsync(int id)
    {
        return await _districtRepository.FindByIdAsync(id);
    }
    
    public async Task<DistrictResponse> SaveAsync(District district)
    {
        //Validate if the district already exists
        var existingDistrict = await _districtRepository.FindByNameAsync(district.DistrictName);
        if (existingDistrict != null) return new DistrictResponse("District already exists");
        
        //Validate if department exists
        var existingDepartment = await _departmentRepository.FindByIdAsync(district.DepartmentId);
        if (existingDepartment == null) return new DistrictResponse("Department not found");
        
        try
        {
            await _districtRepository.AddAsync(district);
            await _unitOfWork.CompleteAsync();

            return new DistrictResponse(district);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new DistrictResponse($"An error occurred when saving the district: {ex.Message}");
        }
    }

    public async Task<DistrictResponse> UpdateAsync(int id, District district)
    {
        var existingDistrict = await _districtRepository.FindByIdAsync(id);
        if (existingDistrict == null) return new DistrictResponse("District not found");

        existingDistrict.DistrictName = district.DistrictName;
        
        try
        {
            _districtRepository.Update(existingDistrict);
            await _unitOfWork.CompleteAsync();

            return new DistrictResponse(existingDistrict);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new DistrictResponse($"An error occurred when updating the district: {ex.Message}");
        }
    }

    public async Task<DistrictResponse> DeleteAsync(int id)
    {
        var existingDistrict = await _districtRepository.FindByIdAsync(id);
        if (existingDistrict == null) return new DistrictResponse("District not found");
        try
        {
            _districtRepository.Remove(existingDistrict);
            await _unitOfWork.CompleteAsync();

            return new DistrictResponse(existingDistrict);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new DistrictResponse($"An error occurred when deleting the district: {ex.Message}");
        }
    }
}