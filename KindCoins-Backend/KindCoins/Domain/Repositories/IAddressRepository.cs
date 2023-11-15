using System.Globalization;
using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface IAddressRepository
{
    Task<IEnumerable<Address>> ListAsync();
    Task AddAsync(Address address);
    Task<Address> FindByIdAsync(int addressId);
    Task<IEnumerable<Address>> FindByCampaignIdAsync(int campaignId);
    Task<IEnumerable<Address>> FindByDistrictIdAsync(int districtId);
    void Update(Address address);
    void Remove(Address address);
}