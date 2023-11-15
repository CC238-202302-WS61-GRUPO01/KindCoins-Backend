using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface ITypeOfCreditCardRepository
{
    Task<IEnumerable<TypeOfCreditCard>> ListAsync();
    Task AddAsync(TypeOfCreditCard typeOfCreditCard);
    Task<TypeOfCreditCard> FindByIdAsync(int id);
    Task<TypeOfCreditCard> FindByNameAsync(string name);
    void Update(TypeOfCreditCard typeOfCreditCard);
    void Remove(TypeOfCreditCard typeOfCreditCard);
}