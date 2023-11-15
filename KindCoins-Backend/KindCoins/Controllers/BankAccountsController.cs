using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Resource;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KindCoins_Backend.KindCoins.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class BankAccountsController : ControllerBase
{
    private readonly IBankAccountService _bankAccountService;
    private readonly IMapper _mapper;
    
    public BankAccountsController(IBankAccountService bankAccountService, IMapper mapper)
    {
        _bankAccountService = bankAccountService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<BankAccountResource>> GetAllAsync()
    {
        var bankAccounts = await _bankAccountService.ListAsync();
        var resources = _mapper.Map<IEnumerable<BankAccount>, IEnumerable<BankAccountResource>>(bankAccounts);
        return resources;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<BankAccountResource>> GetByIdAsync(int id)
    {
        var bankAccount = await _bankAccountService.GetByIdAsync(id);

        if (bankAccount == null)
        {
            return NotFound("Bank Account not found");
        }

        var resource = _mapper.Map<BankAccount, BankAccountResource>(bankAccount);
        return Ok(resource);
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveBankAccountResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var bankAccount = _mapper.Map<SaveBankAccountResource, BankAccount>(resource);
        var result = await _bankAccountService.SaveAsync(bankAccount);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var bankAccountResource = _mapper.Map<BankAccount, BankAccountResource>(result.Resource);
        return Ok(bankAccountResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBankAccountResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var bankAccount = _mapper.Map<SaveBankAccountResource, BankAccount>(resource);
        var result = await _bankAccountService.UpdateAsync(id, bankAccount);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var bankAccountResource = _mapper.Map<BankAccount, BankAccountResource>(result.Resource);
        return Ok(bankAccountResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _bankAccountService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var bankAccountResource = _mapper.Map<BankAccount, BankAccountResource>(result.Resource);
        return Ok(bankAccountResource);
    }
    
}