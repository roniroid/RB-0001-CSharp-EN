using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roniroid.Basics.EF.Data;
using Models = Roniroid.Basics.BL.Models;
using Policies = Roniroid.Basics.API.Policies;

namespace Roniroid.Basics.API.Features.User;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly BasicsDbContext _db;

    public UserController() {

    }
    //public UserController(BasicsDbContext db) => _db = db;

    //[AllowAnonymous]
    [Authorize]
    //[Authorize(Policy = Policies.Identity.UserPolicyNameAdmin)]
    [HttpGet("GetCount")]
    public IActionResult GetCount()
    {
        try
        {
            var userModel = new Models.User();
            return Ok(userModel.CountAll());
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error. Exception: " + ex.Message);
        }
    }

    [Authorize(Policy = Policies.Identity.UserPolicyNameAdmin)]
    [HttpDelete("{id:guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        try
        {
            var result = new Models.User().Delete(id);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound("User not found.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error. Exception: " + ex.Message);
        }
    }
}