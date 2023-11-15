using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class CountryService: ICountryService
{
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public async Task<IEnumerable<Country>> ListAsync()
    {
        return await _countryRepository.ListAsync();
    }
    
    public CountryService(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Country> GetByIdAsync(int id)
    {
        return await _countryRepository.FindByIdAsync(id);
    }

    public async Task<CountryResponse> SaveAsync(Country country)
    {
        //Validate if countryName already exists
        var existingCountry = await _countryRepository.FindByNameAsync(country.CountryName);
        if (existingCountry != null) return new CountryResponse("Country already exists");
        
        try
        {
            await _countryRepository.AddAsync(country);
            await _unitOfWork.CompleteAsync();

            return new CountryResponse(country);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new CountryResponse($"An error occurred when saving the country: {ex.Message}");
        }
    }

    public async Task<CountryResponse> UpdateAsync(int id, Country country)
    {
        var existingCountry = await _countryRepository.FindByIdAsync(id);
        if (existingCountry == null) return new CountryResponse("Country not found");

        existingCountry.CountryName = country.CountryName;
        
        try
        {
            _countryRepository.Update(existingCountry);
            await _unitOfWork.CompleteAsync();

            return new CountryResponse(existingCountry);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new CountryResponse($"An error occurred when updating the country: {ex.Message}");
        }
    }

    public async Task<CountryResponse> DeleteAsync(int id)
    {
        var existingCountry = await _countryRepository.FindByIdAsync(id);
        if (existingCountry == null) return new CountryResponse("Country not found");
        try
        {
            _countryRepository.Remove(existingCountry);
            await _unitOfWork.CompleteAsync();

            return new CountryResponse(existingCountry);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new CountryResponse($"An error occurred when deleting the country: {ex.Message}");
        }
    }
}