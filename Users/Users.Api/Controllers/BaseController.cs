using BuildingBlocks.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Users.Api.Controllers;

public abstract class BaseController : ControllerBase
{
    protected IActionResult CreateResponse(Result result)
    {
        if (result.IsSuccess)
            return Ok(result);

        switch (result.Error.Code)
        {
            case "NotFound":
                return NotFound(result.Error);
            case "BadRequest":
            case "ValidationError":
                return BadRequest(result.Error);
            default:
                return StatusCode(500, result.Error);

        }
    }
    protected string GetCurrentUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null)
            throw new Exception("Not Found");

        return userId;
    }

    // Get the current user's email from the claims
    protected string GetCurrentUserEmail()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);

        if (email is null)
            throw new Exception("NotFound");

        return email;
    }
}
