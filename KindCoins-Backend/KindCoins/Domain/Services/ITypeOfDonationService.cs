using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services;

public interface ITypeOfDonationService
{
    Task<IEnumerable<TypeOfDonation>> ListAsync();
    Task<TypeOfDonationResponse> SaveAsync(TypeOfDonation typeOfDonation);
    Task<TypeOfDonationResponse> UpdateAsync(int id, TypeOfDonation typeOfDonation);
    Task<TypeOfDonationResponse> DeleteAsync(int id);
    Task<TypeOfDonation> GetByIdAsync(int id);
}