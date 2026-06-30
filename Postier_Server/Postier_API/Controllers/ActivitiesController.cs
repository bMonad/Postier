using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Postier_API.Controllers;

public class ActivitiesController(PostierDbContext context) : ActivitiesBaseController
{

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityById(string id)
    {
        try
        {
            if (id == null)
            {
                return BadRequest();
            }
            var response = await context.Activities.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        catch (Exception ex) 
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the activity. "+"\n"+ ex);
        }
    }
}
