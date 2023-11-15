using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class CampaignService : ICampaignService
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITypeOfDonationRepository _typeOfDonationRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CampaignService(ICampaignRepository campaignRepository, IUserRepository userRepository,ITypeOfDonationRepository typeOfDonationRepository ,IUnitOfWork unitOfWork)
    {
        _campaignRepository = campaignRepository;
        _userRepository = userRepository;
        _typeOfDonationRepository = typeOfDonationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Campaign>> ListAsync()
    {
        return await _campaignRepository.ListAsync();
    }
    public async Task<Campaign> GetByIdAsync(int id)
    {
        return await _campaignRepository.FindByIdAsync(id);
    }
    public async Task<CampaignResponse> SaveAsync(Campaign campaign)
    {
        // Validate UserId
        var existingUser = await _userRepository.FindByIdAsync(campaign.UserId);
        if (existingUser == null)
            return new CampaignResponse("Invalid user");
        
        // Validate TypeOfDonationId
        var existingTypeOfDonation = await _typeOfDonationRepository.FindByIdAsync(campaign.TypeOfDonationId);
        if (existingTypeOfDonation == null)
            return new CampaignResponse("Invalid type of donation");

        try
        {
            await _campaignRepository.AddAsync(campaign);
            await _unitOfWork.CompleteAsync();

            return new CampaignResponse(campaign);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new CampaignResponse($"An error occurred when saving the campaign: {ex.Message}");
        }
    }

    public async Task<CampaignResponse> UpdateAsync(int id, Campaign campaign)
    {
        var existingCampaign = await _campaignRepository.FindByIdAsync(id);
        
        if (existingCampaign == null)
            return new CampaignResponse("Campaign not found");
        
        // Validate TypeOfDonationId
        var existingTypeOfDonation = await _typeOfDonationRepository.FindByIdAsync(campaign.TypeOfDonationId);
        if (existingTypeOfDonation == null)
            return new CampaignResponse("Invalid type of donation");
        
        existingCampaign.Name = campaign.Name;
        existingCampaign.Slogan = campaign.Slogan;
        existingCampaign.HeaderPhoto = campaign.HeaderPhoto;
        existingCampaign.AditionalPhoto = campaign.AditionalPhoto;
        existingCampaign.Description = campaign.Description;
        existingCampaign.Goal = campaign.Goal;
        
        try
        {
            _campaignRepository.Update(existingCampaign);
            await _unitOfWork.CompleteAsync();

            return new CampaignResponse(existingCampaign);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new CampaignResponse($"An error occurred when updating the campaign: {ex.Message}");
        }
    }

    public async Task<CampaignResponse> DeleteAsync(int id)
    {
        var existingCampaign = await _campaignRepository.FindByIdAsync(id);

        if (existingCampaign == null)
            return new CampaignResponse("Campaign not found");

        try
        {
            _campaignRepository.Remove(existingCampaign);
            await _unitOfWork.CompleteAsync();

            return new CampaignResponse(existingCampaign);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new CampaignResponse($"An error occurred when deleting the campaign: {ex.Message}");
        }
    }
}