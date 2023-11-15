using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface ITypeOfDonationRepository
{
    Task<IEnumerable<TypeOfDonation>> ListAsync();
    Task AddAsync(TypeOfDonation typeOfDonation);
    Task<TypeOfDonation> FindByIdAsync(int id);
    void Update(TypeOfDonation typeOfDonation);
    void Remove(TypeOfDonation typeOfDonation);
    Task<TypeOfDonation> FindByTypeDonationAsync(string typeDonation);
}