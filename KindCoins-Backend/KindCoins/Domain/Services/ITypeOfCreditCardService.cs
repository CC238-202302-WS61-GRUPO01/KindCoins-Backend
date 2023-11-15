using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services;

public interface ITypeOfCreditCardService
{
    Task<IEnumerable<TypeOfCreditCard>> ListAsync();
    Task<TypeOfCreditCardResponse> SaveAsync(TypeOfCreditCard typeOfCreditCard);
    Task<TypeOfCreditCardResponse> UpdateAsync(int id, TypeOfCreditCard typeOfCreditCard);
    Task<TypeOfCreditCardResponse> DeleteAsync(int id);
    Task<TypeOfCreditCard> GetByIdAsync(int id);
}