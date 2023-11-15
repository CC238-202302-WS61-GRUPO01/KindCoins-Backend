using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class SuscriptionPlanService : ISuscriptionPlanService
{
    private readonly ISuscriptionPlanRepository _suscriptionPlanRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public SuscriptionPlanService(ISuscriptionPlanRepository suscriptionPlanRepository, IUnitOfWork unitOfWork)
    {
        _suscriptionPlanRepository = suscriptionPlanRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<SuscriptionPlan>> ListAsync()
    {
        return await _suscriptionPlanRepository.ListAsync();
    }

    public async Task<SuscriptionPlan> GetByIdAsync(int id)
    {
        return await _suscriptionPlanRepository.FindByIdAsync(id);
    }
    public async Task<SuscriptionPlanResponse> SaveAsync(SuscriptionPlan suscriptionPlan)
    {
        
        //Validate name
        var existingSuscriptionPlan = await _suscriptionPlanRepository.FindByPlanAsync(suscriptionPlan.Plan);
        if (existingSuscriptionPlan != null)
            return new SuscriptionPlanResponse("Suscription plan already exists.");
        
        try
        {
            await _suscriptionPlanRepository.AddAsync(suscriptionPlan);
            await _unitOfWork.CompleteAsync();
            return new SuscriptionPlanResponse(suscriptionPlan);
        }
        catch (Exception e)
        {
            return new SuscriptionPlanResponse($"An error occurred when saving the suscription plan: {e.Message}");
        }
    }
    
    public async Task<SuscriptionPlanResponse> UpdateAsync(int id, SuscriptionPlan suscriptionPlan)
    {
        var existingSuscriptionPlan = await _suscriptionPlanRepository.FindByIdAsync(id);
        if (existingSuscriptionPlan == null)
            return new SuscriptionPlanResponse("Suscription plan not found.");
        
        existingSuscriptionPlan.Plan = suscriptionPlan.Plan;
        try
        {
            _suscriptionPlanRepository.Update(existingSuscriptionPlan);
            await _unitOfWork.CompleteAsync();
            return new SuscriptionPlanResponse(existingSuscriptionPlan);
        }
        catch (Exception e)
        {
            return new SuscriptionPlanResponse($"An error occurred when updating the suscription plan: {e.Message}");
        }
    }
    
    public async Task<SuscriptionPlanResponse> DeleteAsync(int id)
    {
        var existingSuscriptionPlan = await _suscriptionPlanRepository.FindByIdAsync(id);
        if (existingSuscriptionPlan == null)
            return new SuscriptionPlanResponse("Suscription plan not found.");
        
        try
        {
            _suscriptionPlanRepository.Remove(existingSuscriptionPlan);
            await _unitOfWork.CompleteAsync();
            return new SuscriptionPlanResponse(existingSuscriptionPlan);
        }
        catch (Exception e)
        {
            return new SuscriptionPlanResponse($"An error occurred when deleting the suscription plan: {e.Message}");
        }
    }
}