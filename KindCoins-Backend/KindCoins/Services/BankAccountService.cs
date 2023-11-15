using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly ICampaignRepository _campaignRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public BankAccountService(IBankAccountRepository bankAccountRepository, ICampaignRepository campaignRepository , IUnitOfWork unitOfWork)
    {
        _bankAccountRepository = bankAccountRepository;
        _campaignRepository = campaignRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<BankAccount>> ListAsync()
    {
        return await _bankAccountRepository.ListAsync();
    }
    
    public async Task<BankAccount> GetByIdAsync(int id)
    {
        return await _bankAccountRepository.FindByIdAsync(id);
    }
    
    public async Task<BankAccountResponse> SaveAsync(BankAccount bankAccount)
    {
        // Validate if the campaign exists
        var existingCampaign = await _campaignRepository.FindByIdAsync(bankAccount.CampaignId);
        if (existingCampaign == null)
            return new BankAccountResponse("Campaign not found.");
        
        //Validate if the account number exists
        var existingBankAccount = await _bankAccountRepository.FindByAccountNumberAsync(bankAccount.AccountNumber);
        if (existingBankAccount != null)
            return new BankAccountResponse("Account number already exists.");
        
        try
        {
            await _bankAccountRepository.AddAsync(bankAccount);
            await _unitOfWork.CompleteAsync();
            return new BankAccountResponse(bankAccount);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new BankAccountResponse($"An error occurred when saving the bank account: {ex.Message}");
        }
    }
    
    public async Task<BankAccountResponse> UpdateAsync(int id, BankAccount bankAccount)
    {
        var existingBankAccount = await _bankAccountRepository.FindByIdAsync(id);
        if (existingBankAccount == null)
            return new BankAccountResponse("Bank account not found.");
        
        existingBankAccount.AccountNumber = bankAccount.AccountNumber;

        try
        {
            _bankAccountRepository.Update(existingBankAccount);
            await _unitOfWork.CompleteAsync();
            
            return new BankAccountResponse(existingBankAccount);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new BankAccountResponse($"An error occurred when updating the bank account: {ex.Message}");
        }
    }
    
    public async Task<BankAccountResponse> DeleteAsync(int id)
    {
        var existingBankAccount = await _bankAccountRepository.FindByIdAsync(id);
        if (existingBankAccount == null)
            return new BankAccountResponse("Bank account not found.");
        
        try
        {
            _bankAccountRepository.Remove(existingBankAccount);
            await _unitOfWork.CompleteAsync();
            
            return new BankAccountResponse(existingBankAccount);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new BankAccountResponse($"An error occurred when deleting the bank account: {ex.Message}");
        }
    }
}