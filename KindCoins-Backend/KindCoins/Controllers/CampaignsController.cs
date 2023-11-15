using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Resource;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KindCoins_Backend.KindCoins.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CampaignsController : ControllerBase
{
    private readonly ICampaignService _campaignService;
    private readonly IMapper _mapper;

    public CampaignsController(ICampaignService campaignService, IMapper mapper)
    {
        _campaignService = campaignService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CampaignResource>> GetAllAsync()
    {
        var campaigns = await _campaignService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Campaign>, IEnumerable<CampaignResource>>(campaigns);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CampaignResource>> GetByIdAsync(int id)
    {
        var campaign = await _campaignService.GetByIdAsync(id);

        if (campaign == null)
        {
            return NotFound("Campaign not found");
        }

        var resource = _mapper.Map<Campaign, CampaignResource>(campaign);
        return Ok(resource);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCampaignResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var campaign = _mapper.Map<SaveCampaignResource, Campaign>(resource);
        var result = await _campaignService.SaveAsync(campaign);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var campaignResource = _mapper.Map<Campaign, CampaignResource>(result.Resource);
        return Ok(campaignResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCampaignResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var campaign = _mapper.Map<SaveCampaignResource, Campaign>(resource);
        var result = await _campaignService.UpdateAsync(id, campaign);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var campaignResource = _mapper.Map<Campaign, CampaignResource>(result.Resource);
        return Ok(campaignResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _campaignService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var campaignResource = _mapper.Map<Campaign, CampaignResource>(result.Resource);
        return Ok(campaignResource);
    }
}