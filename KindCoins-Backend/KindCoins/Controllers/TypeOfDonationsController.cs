using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Resource;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KindCoins_Backend.KindCoins.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TypeOfDonationsController : ControllerBase
{
    private readonly ITypeOfDonationService _typeOfDonationService;
    private readonly IMapper _mapper;
    
    public TypeOfDonationsController(ITypeOfDonationService typeOfDonationService, IMapper mapper)
    {
        _typeOfDonationService = typeOfDonationService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<TypeOfDonationResource>> GetAllAsync()
    {
        var typeOfDonations = await _typeOfDonationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<TypeOfDonation>,
            IEnumerable<TypeOfDonationResource>>(typeOfDonations);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TypeOfDonationResource>> GetByIdAsync(int id)
    {
        var typeOfDonation = await _typeOfDonationService.GetByIdAsync(id);

        if (typeOfDonation == null)
        {
            return NotFound("type Of Donation not found");
        }

        var resource = _mapper.Map<TypeOfDonation, TypeOfDonationResource>(typeOfDonation);
        return Ok(resource);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTypeOfDonationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var typeOfDonation = _mapper.Map<SaveTypeOfDonationResource, TypeOfDonation>(resource);
        var result = await _typeOfDonationService.SaveAsync(typeOfDonation);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var typeOfDonationResource = _mapper.Map<TypeOfDonation, TypeOfDonationResource>(result.Resource);
        return Ok(typeOfDonationResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTypeOfDonationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var typeOfDonation = _mapper.Map<SaveTypeOfDonationResource, TypeOfDonation>(resource);
        var result = await _typeOfDonationService.UpdateAsync(id, typeOfDonation);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var typeOfDonationResource = _mapper.Map<TypeOfDonation, TypeOfDonationResource>(result.Resource);
        return Ok(typeOfDonationResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _typeOfDonationService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var typeOfDonationResource = _mapper.Map<TypeOfDonation, TypeOfDonationResource>(result.Resource);
        return Ok(typeOfDonationResource);
    }
}