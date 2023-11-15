using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Resource;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KindCoins_Backend.KindCoins.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class DepartmentController: ControllerBase
{
     private readonly IDepartmentService _departmentService;
    private readonly IMapper _mapper;
    
    public DepartmentController(IDepartmentService departmentService, IMapper mapper)
    {
        _departmentService = departmentService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<DepartmentResource>> GetAllAsync()
    {
        var departments = await _departmentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResource>>(departments);
        return resources;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentResource>> GetByIdAsync(int id)
    {
        var departments = await _departmentService.GetByIdAsync(id);

        if (departments == null)
        {
            return NotFound("Departments not found");
        }

        var resource = _mapper.Map<Department, DepartmentResource>(departments);
        return Ok(resource);
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDepartmentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var department = _mapper.Map<SaveDepartmentResource, Department>(resource);
        var result = await _departmentService.SaveAsync(department);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var departmentResource = _mapper.Map<Department, DepartmentResource>(result.Resource);
        return Ok(departmentResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDepartmentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var department = _mapper.Map<SaveDepartmentResource, Department>(resource);
        var result = await _departmentService.UpdateAsync(id, department);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var departmentResource = _mapper.Map<Department, DepartmentResource>(result.Resource);
        return Ok(departmentResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _departmentService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var departmentResource = _mapper.Map<Department, DepartmentResource>(result.Resource);
        return Ok(departmentResource);
    }
}