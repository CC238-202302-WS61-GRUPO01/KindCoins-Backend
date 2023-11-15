using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.Shared.Persistence.Contexts;
using KindCoins_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.KindCoins.Persistence.Repositories;

public class PaymentDataRepository: BaseRepository, IPaymentDataRepository
{
    public PaymentDataRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<PaymentData>> GetAllAsync()
    {
        return await _context.PaymentDatas
            .Include(p => p.TypeOfCreditCard)
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task<PaymentData> FindByIdAsync(int id)
    {
        return await _context.PaymentDatas
            .Include(p => p.User)
            .Include(p => p.TypeOfCreditCard)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<PaymentData>> FindByUserIdAsync(int userId)
    {
        return await _context.PaymentDatas
            .Where(p => p.UserId == userId)
            .Include(p=>p.User)
            .Include(p => p.TypeOfCreditCard)
            .ToListAsync();
    }

    public async Task AddAsync(PaymentData paymentData)
    {
        await _context.PaymentDatas.AddAsync(paymentData);
    }

    public void Update(PaymentData paymentData)
    {
        _context.PaymentDatas.Update(paymentData);
    }

    public void Remove(PaymentData paymentData)
    {
        _context.PaymentDatas.Remove(paymentData);
    }
}