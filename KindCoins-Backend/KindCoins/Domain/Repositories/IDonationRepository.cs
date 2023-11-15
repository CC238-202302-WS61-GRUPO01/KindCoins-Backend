using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface IDonationRepository
{
    Task<IEnumerable<Donation>> GetAllAsync();
    Task<Donation> FindByIdAsync(int id);
    Task<IEnumerable<Donation>> FindByUserIdAsync(int userId);
    Task<IEnumerable<Donation>> FindByCampaignIdAsync(int campaignId);
    Task<IEnumerable<Donation>> FindByTypeOfDonationIdAsync(int typeofdonationId);
    Task AddAsync(Donation donation);
    void Remove(Donation donation);
}