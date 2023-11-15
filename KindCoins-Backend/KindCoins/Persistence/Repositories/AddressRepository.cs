using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.Shared.Persistence.Contexts;
using KindCoins_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.KindCoins.Persistence.Repositories;

public class AddressRepository: BaseRepository, IAddressRepository
{
    public AddressRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Address>> ListAsync()
    {
        return await _context.Addresses
            .Include(p=>p.District)
            .Include(p=>p.Campaign)
            .ToListAsync();
    }
    public async Task AddAsync(Address address)
    {
        await _context.Addresses.AddAsync(address);
    }
    public async Task<Address> FindByIdAsync(int addressId)
    {
        return await _context.Addresses
            .Include(p=>p.District)
            .Include(p=>p.Campaign)
            .FirstOrDefaultAsync(p => p.Id == addressId);
    }
    
    public async Task<IEnumerable<Address>> FindByCampaignIdAsync(int campaignId)
    {
        return await _context.Addresses
            .Where(p => p.CampaignId == campaignId)
            .Include(p=>p.Campaign)
            .ToListAsync();
    }

    public async Task<IEnumerable<Address>> FindByDistrictIdAsync(int districtId)
    {
        return await _context.Addresses
            .Where(p => p.DistrictId == districtId)
            .Include(p => p.District)
            .ToListAsync();
    }

    public void Update(Address address)
    {
        _context.Addresses.Update(address);
    }

    public void Remove(Address address)
    {
        _context.Addresses.Remove(address);
    }
}