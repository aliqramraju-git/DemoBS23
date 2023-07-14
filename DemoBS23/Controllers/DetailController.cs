using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace DemoBS23.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DetailController : ControllerBase
{
    private readonly DemoContext _dbContext;

    public DetailController(DemoContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("GetAll")]
    public ActionResult GetAll()
    {
        try
        {
            var result = _dbContext.Details
                .Select(element => new
                {
                    id = element.Id,
                    employeeId = element.EmployeeId,
                    employeeName = element.Employee.Name,
                    projectId = element.ProjectId,
                    projectName = element.Project.Name,
                    createdTime = element.CreatedTime.ToString("dd/MMM/yyyy hh:mm tt")
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
            var result = _dbContext.Details.Where(element => element.Id == id)
                .Select(element => new
                {
                    id = element.Id,
                    employeeId = element.EmployeeId,
                    employeeName = element.Employee.Name,
                    projectId = element.ProjectId,
                    projectName = element.Project.Name,
                    createdTime = element.CreatedTime.ToString("dd/MMM/yyyy hh:mm tt")
                }).ToList();
            if (result is null) return Ok("This detail mapping is not exist!");
            return Ok(result);

        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
