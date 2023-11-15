using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services;

public interface IBankAccountService
{
    Task<IEnumerable<BankAccount>> ListAsync();
    Task<BankAccountResponse> SaveAsync(BankAccount bankAccount);
    Task<BankAccountResponse> UpdateAsync(int id, BankAccount campaign);
    Task<BankAccountResponse> DeleteAsync(int id);
    Task<BankAccount> GetByIdAsync(int id);
}