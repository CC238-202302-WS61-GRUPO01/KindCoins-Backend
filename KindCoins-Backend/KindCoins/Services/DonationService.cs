using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class DonationService: IDonationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IDonationRepository _donationRepository;
    private readonly ICampaignRepository _campaignRepository;
    private readonly ITypeOfDonationRepository _typeOfDonationRepository;

    public DonationService(IUnitOfWork unitOfWork, IUserRepository userRepository, IDonationRepository donationRepository,
        ICampaignRepository campaignRepository, ITypeOfDonationRepository typeOfDonationRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _donationRepository = donationRepository;
        _campaignRepository = campaignRepository;
        _typeOfDonationRepository = typeOfDonationRepository;
    }
    
    public async Task<IEnumerable<Donation>> ListAsync()
    {
        return await _donationRepository.GetAllAsync();
    }

    public async Task<DonationResponse> SaveAsync(Donation donation)
    {
        //Validate if user exits
        var existingUser = await _userRepository.FindByIdAsync(donation.UserId);
        if (existingUser == null) return new DonationResponse("User with id " + donation.UserId + " not found");
        
        //Validate if campaign exist
        var existingCampaign = await _campaignRepository.FindByIdAsync(donation.CampaignId);
        if (existingCampaign == null) return new DonationResponse("Campaign with id " + donation.CampaignId + " not found");

        //Validate if type of donation exist
        var existingTypeOfDonation = await _typeOfDonationRepository.FindByIdAsync(donation.TypeOfDonationId);
        if (existingTypeOfDonation == null) return new DonationResponse("Type of donation with id " + donation.TypeOfDonationId + " not found");

        try
        {
            await _donationRepository.AddAsync(donation);
            await _unitOfWork.CompleteAsync();
            return new DonationResponse(donation);
        }
        catch (Exception ex)
        {
            return new DonationResponse($"An error occurred while saving the donation: {ex.Message}");
        }
    }

    public async Task<DonationResponse> DeleteAsync(int id)
    {
        var existingDonation = await _donationRepository.FindByIdAsync(id);
        if (existingDonation == null) return new DonationResponse("Donation not found");
        try
        {
            _donationRepository.Remove(existingDonation);
            await _unitOfWork.CompleteAsync();
            return new DonationResponse(existingDonation);
        }
        catch (Exception ex)
        {
            return new DonationResponse($"An error occurred while updating the donation: {ex.Message}");
        }
    }

    public async Task<Donation> GetByIdAsync(int id)
    {
        return await _donationRepository.FindByIdAsync(id);
    }

    public async Task<IEnumerable<Donation>> GetByCampaignIdAsync(int campaignId)
    {
        return await _donationRepository.FindByCampaignIdAsync(campaignId);
    }

    public async Task<IEnumerable<Donation>> GetByTypeOfDonationIdAsync(int typeofdonationId)
    {
        return await _donationRepository.FindByTypeOfDonationIdAsync(typeofdonationId);
    }
}