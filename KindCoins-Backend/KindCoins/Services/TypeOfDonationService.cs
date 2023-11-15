using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class TypeOfDonationService : ITypeOfDonationService
{
    private readonly ITypeOfDonationRepository _typeOfDonationRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public TypeOfDonationService(ITypeOfDonationRepository typeOfDonationRepository, IUnitOfWork unitOfWork)
    {
        _typeOfDonationRepository = typeOfDonationRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<TypeOfDonation>> ListAsync()
    {
        return await _typeOfDonationRepository.ListAsync();
    }
    public async Task<TypeOfDonation> GetByIdAsync(int id)
    {
        return await _typeOfDonationRepository.FindByIdAsync(id);
    }
    public async Task<TypeOfDonationResponse> SaveAsync(TypeOfDonation typeOfDonation)
    {
        
        //Validate name
        var existingTypeOfDonation = await _typeOfDonationRepository.FindByTypeDonationAsync(typeOfDonation.TypeDonation);
        if (existingTypeOfDonation != null)
            return new TypeOfDonationResponse("Type of donation already exists.");
        
        try
        {
            await _typeOfDonationRepository.AddAsync(typeOfDonation);
            await _unitOfWork.CompleteAsync();
            return new TypeOfDonationResponse(typeOfDonation);
        }
        catch (Exception e)
        {
            return new TypeOfDonationResponse($"An error occurred when saving the type of donation: {e.Message}");
        }
    }
    
    public async Task<TypeOfDonationResponse> UpdateAsync(int id, TypeOfDonation typeOfDonation)
    {
        var existingTypeOfDonation = await _typeOfDonationRepository.FindByIdAsync(id);
        if (existingTypeOfDonation == null)
            return new TypeOfDonationResponse("Type of donation not found.");
        
        existingTypeOfDonation.TypeDonation = typeOfDonation.TypeDonation;
        try
        {
            _typeOfDonationRepository.Update(existingTypeOfDonation);
            await _unitOfWork.CompleteAsync();
            return new TypeOfDonationResponse(existingTypeOfDonation);
        }
        catch (Exception e)
        {
            return new TypeOfDonationResponse($"An error occurred when updating the type of donation: {e.Message}");
        }
    }
    
    public async Task<TypeOfDonationResponse> DeleteAsync(int id)
    {
        var existingTypeOfDonation = await _typeOfDonationRepository.FindByIdAsync(id);
        if (existingTypeOfDonation == null)
            return new TypeOfDonationResponse("Type of donation not found.");
        try
        {
            _typeOfDonationRepository.Remove(existingTypeOfDonation);
            await _unitOfWork.CompleteAsync();
            return new TypeOfDonationResponse(existingTypeOfDonation);
        }
        catch (Exception e)
        {
            return new TypeOfDonationResponse($"An error occurred when deleting the type of donation: {e.Message}");
        }
    }
}