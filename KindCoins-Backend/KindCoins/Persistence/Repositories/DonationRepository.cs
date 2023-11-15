using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.Shared.Persistence.Contexts;
using KindCoins_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.KindCoins.Persistence.Repositories;

public class DonationRepository: BaseRepository, IDonationRepository
{
    public DonationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Donation>> GetAllAsync()
    {
        return await _context.Donations
            .Include(p => p.User)
            .Include(p => p.TypeOfDonation)
            .Include(p => p.Campaign)
            .ToListAsync();
    }

    public async Task<Donation> FindByIdAsync(int donationId)
    {
        return await _context.Donations
            .Include(p => p.User)
            .Include(p => p.TypeOfDonation)
            .Include(p => p.Campaign)
            .FirstOrDefaultAsync(p => p.Id == donationId);
    }

    public async Task<IEnumerable<Donation>> FindByUserIdAsync(int userId)
    {
        return await _context.Donations
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .Include(p => p.TypeOfDonation)
            .Include(p => p.Campaign)
            .ToListAsync();
    }

    public async Task<IEnumerable<Donation>> FindByCampaignIdAsync(int campaignId)
    {
        return await _context.Donations
            .Where(p => p.CampaignId == campaignId)
            .Include(p => p.User)
            .Include(p => p.TypeOfDonation)
            .Include(p => p.Campaign)
            .ToListAsync();
    }

    public async Task<IEnumerable<Donation>> FindByTypeOfDonationIdAsync(int typeofdonationId)
    {
        return await _context.Donations
            .Where(p => p.TypeOfDonationId == typeofdonationId)
            .Include(p => p.User)
            .Include(p => p.TypeOfDonation)
            .Include(p => p.Campaign)
            .ToListAsync();
    }

    public async Task AddAsync(Donation donation)
    {
        await _context.Donations.AddAsync(donation);
    }

    public void Remove(Donation donation)
    { 
        _context.Donations.Remove(donation);
    }
}