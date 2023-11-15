using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Resource;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KindCoins_Backend.KindCoins.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;
    private readonly IMapper _mapper;
    
    public AddressesController(IAddressService addressService, IMapper mapper)
    {
        _addressService = addressService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<AddressResource>> GetAllAsync()
    {
        var addresses = await _addressService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Address>, IEnumerable<AddressResource>>(addresses);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<AddressResource>> GetByIdAsync(int id)
    {
        var address = await _addressService.GetByIdAsync(id);

        if (address == null)
        {
            return NotFound("Address not found");
        }

        var resource = _mapper.Map<Address, AddressResource>(address);
        return Ok(resource);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAddressResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var address = _mapper.Map<SaveAddressResource, Address>(resource);
        var result = await _addressService.SaveAsync(address);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var addressResource = _mapper.Map<Address, AddressResource>(result.Resource);
        return Ok(addressResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAddressResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var address = _mapper.Map<SaveAddressResource, Address>(resource);
        var result = await _addressService.UpdateAsync(id, address);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var addressResource = _mapper.Map<Address, AddressResource>(result.Resource);
        return Ok(addressResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _addressService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var addressResource = _mapper.Map<Address, AddressResource>(result.Resource);
        return Ok(addressResource);
    }
}