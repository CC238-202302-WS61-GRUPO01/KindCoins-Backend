using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class TypeOfCreditCardService: ITypeOfCreditCardService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITypeOfCreditCardRepository _typeOfCreditCardRepository;

    public TypeOfCreditCardService(IUnitOfWork unitOfWork, ITypeOfCreditCardRepository typeOfCreditCardRepository)
    {
        _unitOfWork = unitOfWork;
        _typeOfCreditCardRepository = typeOfCreditCardRepository;
    }
    
    public async Task<IEnumerable<TypeOfCreditCard>> ListAsync()
    {
        return await _typeOfCreditCardRepository.ListAsync();
    }

    public async Task<TypeOfCreditCard> GetByIdAsync(int id)
    {
        return await _typeOfCreditCardRepository.FindByIdAsync(id);
    }
    public async Task<TypeOfCreditCardResponse> SaveAsync(TypeOfCreditCard typeOfCreditCard)
    {
        //Validate name
        var existingTypeOfCreditCard = await _typeOfCreditCardRepository.FindByNameAsync(typeOfCreditCard.Name);
        if (existingTypeOfCreditCard != null)
            return new TypeOfCreditCardResponse("Type of credit card already exists.");
        
        try
        {
            await _typeOfCreditCardRepository.AddAsync(typeOfCreditCard);
            await _unitOfWork.CompleteAsync();
            return new TypeOfCreditCardResponse(typeOfCreditCard);
        }
        catch (Exception e)
        {
            return new TypeOfCreditCardResponse($"An error occurred when saving the type of credit card: {e.Message}");
        }
    }

    public async Task<TypeOfCreditCardResponse> UpdateAsync(int id, TypeOfCreditCard typeOfCreditCard)
    {
        var existingTypeOfCreditCard = await _typeOfCreditCardRepository.FindByIdAsync(id);
        if (existingTypeOfCreditCard == null)
            return new TypeOfCreditCardResponse("Type of credit card not found.");
        
        existingTypeOfCreditCard.Name = typeOfCreditCard.Name;
        try
        {
            _typeOfCreditCardRepository.Update(existingTypeOfCreditCard);
            await _unitOfWork.CompleteAsync();
            return new TypeOfCreditCardResponse(existingTypeOfCreditCard);
        }
        catch (Exception e)
        {
            return new TypeOfCreditCardResponse($"An error occurred when updating the type of credit card: {e.Message}");
        }
    }

    public async Task<TypeOfCreditCardResponse> DeleteAsync(int id)
    {
        var existingTypeOfCreditCard = await _typeOfCreditCardRepository.FindByIdAsync(id);
        if (existingTypeOfCreditCard == null)
            return new TypeOfCreditCardResponse("Type of credit card not found.");
        try
        {
            _typeOfCreditCardRepository.Remove(existingTypeOfCreditCard);
            await _unitOfWork.CompleteAsync();
            return new TypeOfCreditCardResponse(existingTypeOfCreditCard);
        }
        catch (Exception e)
        {
            return new TypeOfCreditCardResponse($"An error occurred when deleting the type of credit card: {e.Message}");
        }
    }
}