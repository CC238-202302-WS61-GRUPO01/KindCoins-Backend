using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.Shared.Persistence.Contexts;
using KindCoins_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.KindCoins.Persistence.Repositories;

public class BankAccountRepository : BaseRepository , IBankAccountRepository
{
    
    public BankAccountRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<BankAccount>> ListAsync()
    {
        return await _context.BankAccounts  
            .Include(p=>p.Campaign)
            .ToListAsync();
    }
    
    public async Task AddAsync(BankAccount bankAccount)
    {
        await _context.BankAccounts.AddAsync(bankAccount);
    }

    public async Task<BankAccount> FindByIdAsync(int bankAccountId)
    {
        return await _context.BankAccounts
            .Include(p=>p.Campaign)
            .FirstOrDefaultAsync(p => p.Id == bankAccountId);
    }

    public async Task<IEnumerable<BankAccount>> FindByCampaignIdAsync(int campaignId)
    {
        return await _context.BankAccounts
            .Where(p => p.CampaignId == campaignId)
            .Include(p=>p.Campaign)
            .ToListAsync();
    }

    public void Update(BankAccount bankAccount)
    {
        _context.BankAccounts.Update(bankAccount);
    }

    public void Remove(BankAccount bankAccount)
    {
        _context.BankAccounts.Remove(bankAccount);
    }
    
    public async Task<BankAccount> FindByAccountNumberAsync(string accountNumber)
    {
        return await _context.BankAccounts
            .Include(p=>p.Campaign)
            .FirstOrDefaultAsync(p => p.AccountNumber == accountNumber);
    }
}