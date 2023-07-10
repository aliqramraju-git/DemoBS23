using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace Demo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly DemoContext _dbContext;

    public EmployeeController(DemoContext dbContext)
    {
        _dbContext = dbContext;
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
    public ActionResult Create(int id)
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
}
