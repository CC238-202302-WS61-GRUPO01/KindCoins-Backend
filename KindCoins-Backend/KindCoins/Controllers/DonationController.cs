using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Resource;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KindCoins_Backend.KindCoins.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class DonationController : ControllerBase
{
    private readonly IDonationService _donationService;
    private readonly IMapper _mapper;

    public DonationController(IDonationService donationService, IMapper mapper)
    {
        _donationService = donationService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<DonationResource>> GetAllAsync()
    {
        var donations = await _donationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Donation>, IEnumerable<DonationResource>>(donations);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Donation>> GetByIdAsync(int id)
    {
        var donation = await _donationService.GetByIdAsync(id);

        if (donation == null)
        {
            return NotFound("Donation not found");
        }

        var resource = _mapper.Map<Donation, DonationResource>(donation);
        return Ok(resource);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDonationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var donation = _mapper.Map<SaveDonationResource, Donation>(resource);
        var result = await _donationService.SaveAsync(donation);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var donationResource = _mapper.Map<Donation, DonationResource>(result.Resource);
        return Ok(donationResource);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _donationService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var donationResource = _mapper.Map<Donation, DonationResource>(result.Resource);
        return Ok(donationResource);
    }
}