using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Resource;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KindCoins_Backend.KindCoins.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class DistrictController: ControllerBase
{
     private readonly IDistrictService _districtService;
    private readonly IMapper _mapper;
    
    public DistrictController(IDistrictService districtService, IMapper mapper)
    {
        _districtService = districtService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<DistrictResource>> GetAllAsync()
    {
        var districts = await _districtService.ListAsync();
        var resources = _mapper.Map<IEnumerable<District>, IEnumerable<DistrictResource>>(districts);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<DistrictResource>> GetByIdAsync(int id)
    {
        var districts = await _districtService.GetByIdAsync(id);

        if (districts == null)
        {
            return NotFound("Districts not found");
        }

        var resource = _mapper.Map<District, DistrictResource>(districts);
        return Ok(resource);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDistrictResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var district = _mapper.Map<SaveDistrictResource, District>(resource);
        var result = await _districtService.SaveAsync(district);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var districtResource = _mapper.Map<District, DistrictResource>(result.Resource);
        return Ok(districtResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDistrictResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var district = _mapper.Map<SaveDistrictResource, District>(resource);
        var result = await _districtService.UpdateAsync(id, district);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var districtResource = _mapper.Map<District, DistrictResource>(result.Resource);
        return Ok(districtResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _districtService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var districtResource = _mapper.Map<District, DistrictResource>(result.Resource);
        return Ok(districtResource);
    }
}