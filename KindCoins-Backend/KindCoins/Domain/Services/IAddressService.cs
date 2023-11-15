using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services;

public interface IAddressService 
{
    Task<IEnumerable<Address>> ListAsync();
    Task<AddressResponse> SaveAsync(Address address);
    Task<AddressResponse> UpdateAsync(int id, Address address);
    Task<AddressResponse> DeleteAsync(int id);
    Task<Address> GetByIdAsync(int id);
}