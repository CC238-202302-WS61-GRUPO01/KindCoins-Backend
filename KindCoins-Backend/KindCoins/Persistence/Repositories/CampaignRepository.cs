using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.Shared.Persistence.Contexts;
using KindCoins_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.KindCoins.Persistence.Repositories;

public class CampaignRepository : BaseRepository , ICampaignRepository
{
    
    public CampaignRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Campaign>> ListAsync()
    {
        return await _context.Campaigns
            .Include(p=>p.User)
            .Include(p=>p.TypeOfDonation)
            .ToListAsync();
    }
    
    public async Task AddAsync(Campaign campaign)
    {
        await _context.Campaigns.AddAsync(campaign);
    }

    public async Task<Campaign> FindByIdAsync(int campaignId)
    {
        return await _context.Campaigns
            .Include(p=>p.User)
            .Include(p=>p.TypeOfDonation)
            .FirstOrDefaultAsync(p => p.Id == campaignId);
    }
    
    public async Task<IEnumerable<Campaign>> FindByUserIdAsync(int userId)
    {
        return await _context.Campaigns
            .Where(p => p.UserId == userId)
            .Include(p=>p.User)
            .Include(p=>p.TypeOfDonation)
            .ToListAsync();
    }

    public void Update(Campaign campaign)
    {
        _context.Campaigns.Update(campaign);
    }

    public void Remove(Campaign campaign)
    {
        _context.Campaigns.Remove(campaign);
    }
}