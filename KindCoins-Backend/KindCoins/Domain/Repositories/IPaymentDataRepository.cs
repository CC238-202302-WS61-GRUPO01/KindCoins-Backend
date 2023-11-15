using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface IPaymentDataRepository
{
    Task<IEnumerable<PaymentData>> GetAllAsync();
    Task<PaymentData> FindByIdAsync(int id);
    Task<IEnumerable<PaymentData>> FindByUserIdAsync(int userId);
    Task AddAsync(PaymentData paymentData);
    void Update(PaymentData paymentData);
    void Remove(PaymentData paymentData);
}