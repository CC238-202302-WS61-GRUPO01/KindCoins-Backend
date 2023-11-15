using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services;

public interface ICampaignService
{
    Task<IEnumerable<Campaign>> ListAsync();
    Task<Campaign> GetByIdAsync(int id);
    Task<CampaignResponse> SaveAsync(Campaign campaign);
    Task<CampaignResponse> UpdateAsync(int id, Campaign campaign);
    Task<CampaignResponse> DeleteAsync(int id);
}