using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services;

public interface IDonationService
{
    Task<IEnumerable<Donation>> ListAsync();
    Task<DonationResponse> SaveAsync(Donation donation);
    Task<DonationResponse> DeleteAsync(int id);
    Task<Donation> GetByIdAsync(int id);
    Task<IEnumerable<Donation>> GetByCampaignIdAsync(int campaignId);
    Task<IEnumerable<Donation>>GetByTypeOfDonationIdAsync(int typeofdonationId);
}