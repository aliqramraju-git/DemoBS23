using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace DemoBS23.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly DemoContext _dbContext;
    private readonly IMapper _mapper;

    public EmployeeController(DemoContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet("GetAll")]
    public ActionResult GetAll()
    {
        try
        {
            var result = _dbContext.Employees
                .Select(element => new
                {
                    id = element.Id,
                    name = element.Name
                });
            return Ok(result);

        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpGet("GetById")]
    public ActionResult GetById(int id)
    {
        try
        {
            var result = _dbContext.Employees.Where(element => element.Id == id)
                .Select(element => new
                {
                    id = element.Id,
                    name = element.Name
                }).FirstOrDefault();
            if (result is null) return Ok("This employee is not exist!");
            return Ok(result);

        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpPost("Create")]
    public async Task<ActionResult> Create([FromBody] EmployeeVM newEmployee)
    {
        try
        {
            var result = _dbContext.Employees.FirstOrDefault(element => element.Id == newEmployee.Id);
            if (result is not null) return BadRequest("This employee already exist!");

            Employee employee = _mapper.Map<Employee>(newEmployee);
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return Ok(employee);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPut("Update")]
    public async Task<ActionResult> Update([FromBody] EmployeeVM newEmployee)
    {
        try
        {
            var transaction = _dbContext.Database.BeginTransaction();

            Employee? oldEmployee = _dbContext.Employees.FirstOrDefault(element => element.Id == newEmployee.Id);
            if (oldEmployee is null) return BadRequest("Employee is not exist!");
            
            _mapper.Map(newEmployee, oldEmployee);
            await _dbContext.SaveChangesAsync();
            transaction.Commit();
            return Ok(oldEmployee);
        }
        catch (Exception)
        {
            throw;
        }

    }

    [HttpDelete("Delete")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            Employee? employee = _dbContext.Employees.FirstOrDefault(element => element.Id == id);
            if (employee is null) return BadRequest("Zone is not exist!");
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return Ok(employee);

        }
        catch (Exception ex)
        {
            throw;
        }

    }
}
