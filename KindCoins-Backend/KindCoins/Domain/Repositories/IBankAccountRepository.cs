using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface IBankAccountRepository
{
    Task<IEnumerable<BankAccount>> ListAsync();
    Task AddAsync(BankAccount bankAccount);
    Task<BankAccount> FindByIdAsync(int id);
    void Update(BankAccount bankAccount);
    void Remove(BankAccount bankAccount);
    
    Task<BankAccount> FindByAccountNumberAsync(string accountNumber);
}