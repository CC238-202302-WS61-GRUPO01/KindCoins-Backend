using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.Shared.Persistence.Contexts;
using KindCoins_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.KindCoins.Persistence.Repositories;

public class TypeOfDonationRepository : BaseRepository , ITypeOfDonationRepository
{
    
    public TypeOfDonationRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<TypeOfDonation>> ListAsync()
    {
        return await _context.TypeOfDonations.ToListAsync();
    }
    
    public async Task AddAsync(TypeOfDonation typeOfDonation)
    {
        await _context.TypeOfDonations.AddAsync(typeOfDonation);
    }
    
    public async Task<TypeOfDonation> FindByIdAsync(int id)
    {
        return await _context.TypeOfDonations
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<TypeOfDonation> FindByTypeDonationAsync(string typeDonation)
    {
        return await _context.TypeOfDonations
            .FirstOrDefaultAsync(p => p.TypeDonation == typeDonation);
    }
    
    public void Update(TypeOfDonation typeOfDonation)
    {
        _context.TypeOfDonations.Update(typeOfDonation);
    }
    
    public void Remove(TypeOfDonation typeOfDonation)
    {
        _context.TypeOfDonations.Remove(typeOfDonation);
    }
}