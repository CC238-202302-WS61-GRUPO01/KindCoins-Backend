using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services;

public interface IPaymentDataService
{
    Task<IEnumerable<PaymentData>> ListAsync();
    Task<PaymentDataResponse> SaveAsync(PaymentData paymentData);
    Task<PaymentDataResponse> UpdateAsync(int id, PaymentData paymentData);
    Task<PaymentDataResponse> DeleteAsync(int id);
    Task<PaymentData> GetByIdAsync(int id);
}