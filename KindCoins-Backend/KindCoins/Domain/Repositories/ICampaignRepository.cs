using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface ICampaignRepository
{
    Task<IEnumerable<Campaign>> ListAsync();
    Task AddAsync(Campaign campaign);
    Task<Campaign> FindByIdAsync(int campaignId);
    Task<IEnumerable<Campaign>> FindByUserIdAsync(int userId);
    void Update(Campaign campaign);
    void Remove(Campaign campaign);
}