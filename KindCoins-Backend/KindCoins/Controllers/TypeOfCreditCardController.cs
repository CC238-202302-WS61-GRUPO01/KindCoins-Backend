using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Resource;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KindCoins_Backend.KindCoins.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TypeOfCreditCardController: ControllerBase
{
    private readonly ITypeOfCreditCardService _typeOfCreditCardService;
    private readonly IMapper _mapper;

    public TypeOfCreditCardController(ITypeOfCreditCardService typeOfCreditCardService, IMapper mapper)
    {
        _typeOfCreditCardService = typeOfCreditCardService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<TypeOfCreditCardResource>> GetAllAsync()
    {
        var typeOfCreditCards = await _typeOfCreditCardService.ListAsync();
        var resources = _mapper.Map<IEnumerable<TypeOfCreditCard>,
            IEnumerable<TypeOfCreditCardResource>>(typeOfCreditCards);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TypeOfCreditCardResource>> GetByIdAsync(int id)
    {
        var typeOfCreditCards = await _typeOfCreditCardService.GetByIdAsync(id);

        if (typeOfCreditCards == null)
        {
            return NotFound("type Of Credit Card not found");
        }

        var resource = _mapper.Map<TypeOfCreditCard, TypeOfCreditCardResource>(typeOfCreditCards);
        return Ok(resource);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTypeOfCreditCardResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var typeOfCreditCards = _mapper.Map<SaveTypeOfCreditCardResource, TypeOfCreditCard>(resource);
        var result = await _typeOfCreditCardService.SaveAsync(typeOfCreditCards);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var typeOfCreditCardResource = _mapper.Map<TypeOfCreditCard, TypeOfCreditCardResource>(result.Resource);
        return Ok(typeOfCreditCardResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTypeOfCreditCardResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var typeOfCreditCards = _mapper.Map<SaveTypeOfCreditCardResource, TypeOfCreditCard>(resource);
        var result = await _typeOfCreditCardService.UpdateAsync(id, typeOfCreditCards);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var typeOfCreditCardResource = _mapper.Map<TypeOfCreditCard, TypeOfCreditCardResource>(result.Resource);
        return Ok(typeOfCreditCardResource);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _typeOfCreditCardService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var typeOfCreditCardResource = _mapper.Map<TypeOfCreditCard, TypeOfCreditCardResource>(result.Resource);
        return Ok(typeOfCreditCardResource);
    }
}