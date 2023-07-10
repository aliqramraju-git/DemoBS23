using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Security.Claims;

namespace Demo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly DemoContext _dbContext;

    public ProjectController(DemoContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("GetAll")]
    public ActionResult GetAll()
    {
        try
        {
            var result = _dbContext.Projects
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
            var result = _dbContext.Projects.Where(element => element.Id == id)
                .Select(element => new
                {
                    id = element.Id,
                    name = element.Name
                }).FirstOrDefault();
            if (result is null) return Ok("This project is not exist!");
            return Ok(result);

        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpPost("MapProject")]
    public async Task<ActionResult> Update([FromBody] DetailVM newMapping)
    {
        try
        {
            Detail? oldProjectMapping = _dbContext.Details.FirstOrDefault(element => element.ProjectId == newMapping.ProjectId && element.EmployeeId == newMapping.EmployeeId);
            if (oldProjectMapping != null) return Ok("This mapping already exist!");

            Detail mapping = new()
            {
                ProjectId = newMapping.ProjectId,
                EmployeeId = newMapping.EmployeeId,
                CreatedTime = DateTime.Now
            };

            await _dbContext.Details.AddAsync(mapping);
            await _dbContext.SaveChangesAsync();
            return Ok(mapping);
        }
        catch (Exception ex)
        {
            throw;
        }

    }
}
