using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class PaymentDataService: IPaymentDataService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITypeOfCreditCardRepository _typeOfCreditCardRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPaymentDataRepository _paymentDataRepository;

    public PaymentDataService(IUnitOfWork unitOfWork, ITypeOfCreditCardRepository typeOfCreditCardRepository,
        IUserRepository userRepository, IPaymentDataRepository paymentDataRepository)
    {
        _unitOfWork = unitOfWork;
        _typeOfCreditCardRepository = typeOfCreditCardRepository;
        _userRepository = userRepository;
        _paymentDataRepository = paymentDataRepository;
    }
    
    public async Task<IEnumerable<PaymentData>> ListAsync()
    {
        return await _paymentDataRepository.GetAllAsync();
    }

    public async Task<PaymentDataResponse> SaveAsync(PaymentData paymentData)
    {
        //Validate if user exits
        var existingUser = await _userRepository.FindByIdAsync(paymentData.UserId);
        if (existingUser == null) return new PaymentDataResponse("User with id " + paymentData.UserId + " not found");
        
        //Validate if type of credit card exist
        var existingTypeOfCreditCard = await _typeOfCreditCardRepository.FindByIdAsync(paymentData.TypeOfCreditCardId);
        if (existingTypeOfCreditCard == null) return new PaymentDataResponse("Type of credit card with with id " + paymentData.TypeOfCreditCardId + " not found");
        try
        {
            await _paymentDataRepository.AddAsync(paymentData);
            await _unitOfWork.CompleteAsync();
            return new PaymentDataResponse(paymentData);
        }
        catch (Exception ex)
        {
            return new PaymentDataResponse($"An error occurred while saving the payment data: {ex.Message}");
        }
    }

    public async Task<PaymentDataResponse> UpdateAsync(int id, PaymentData paymentData)
    {
        var existingPaymentData = await _paymentDataRepository.FindByIdAsync(id);
        if (existingPaymentData == null) return new PaymentDataResponse("Payment data not found");
        existingPaymentData.CardNumber = paymentData.CardNumber;
        existingPaymentData.ExpirationDate = paymentData.ExpirationDate;
        existingPaymentData.CVV = paymentData.CVV;
        existingPaymentData.LastName = paymentData.LastName;
        existingPaymentData.FirstName = paymentData.FirstName;
        existingPaymentData.Email = paymentData.Email;
        try
        {
            _paymentDataRepository.Update(existingPaymentData);
            await _unitOfWork.CompleteAsync();
            return new PaymentDataResponse(existingPaymentData);
        }
        catch (Exception ex)
        {
            return new PaymentDataResponse($"An error occurred while updating the payment data: {ex.Message}");
        }
    }

    public async Task<PaymentDataResponse> DeleteAsync(int id)
    {
        var existingPaymentData = await _paymentDataRepository.FindByIdAsync(id);
        if (existingPaymentData == null) return new PaymentDataResponse("Payment data not found");
        try
        {
            _paymentDataRepository.Remove(existingPaymentData);
            await _unitOfWork.CompleteAsync();
            return new PaymentDataResponse(existingPaymentData);
        }
        catch (Exception ex)
        {
            return new PaymentDataResponse($"An error occurred while updating the payment data: {ex.Message}");
        }
    }

    public async Task<PaymentData> GetByIdAsync(int id)
    {
        return await _paymentDataRepository.FindByIdAsync(id);
    }
}