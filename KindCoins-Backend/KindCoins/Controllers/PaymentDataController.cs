using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Resource;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KindCoins_Backend.KindCoins.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PaymentDataController: ControllerBase
{
    private readonly IPaymentDataService _paymentDataService;
    private readonly IMapper _mapper;

    public PaymentDataController(IPaymentDataService paymentDataService, IMapper mapper)
    {
        _paymentDataService = paymentDataService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<PaymentDataResource>> GetAllAsync()
    {
        var paymentDatas = await _paymentDataService.ListAsync();
        var resources = _mapper.Map<IEnumerable<PaymentData>, IEnumerable<PaymentDataResource>>(paymentDatas);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentData>> GetByIdAsync(int id)
    {
        var paymentData = await _paymentDataService.GetByIdAsync(id);

        if (paymentData == null)
        {
            return NotFound("Payment data not found");
        }

        var resource = _mapper.Map<PaymentData, PaymentDataResource>(paymentData);
        return Ok(resource);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePaymentDataResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var paymentData = _mapper.Map<SavePaymentDataResource, PaymentData>(resource);
        var result = await _paymentDataService.SaveAsync(paymentData);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var paymentDataResource = _mapper.Map<PaymentData, PaymentDataResource>(result.Resource);
        return Ok(paymentDataResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePaymentDataResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var paymentData = _mapper.Map<SavePaymentDataResource, PaymentData>(resource);
        var result = await _paymentDataService.UpdateAsync(id, paymentData);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var paymentDataResource = _mapper.Map<PaymentData, PaymentDataResource>(result.Resource);
        return Ok(paymentDataResource);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _paymentDataService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var paymentDataResource = _mapper.Map<PaymentData, PaymentDataResource>(result.Resource);
        return Ok(paymentDataResource);
    }
}