using BuildingBlocks.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Games.Api.Controllers;

public abstract class BaseController : ControllerBase
{
    protected IActionResult CreateResponse(Result result)
    {
        if (result.IsSuccess)
            return Ok(result);

        switch (result.Error.Code)
        {
            case "NotFound":
                return NotFound(result);
            case "BadRequest":
                return BadRequest(result);
            default:
                return StatusCode(500, result);

        }
    }
    protected string GetCurrentUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null)
            throw new Exception("Not Found");

        return userId;
    }

    protected string GetCurrentUserRole()
    {
        var email = User.FindFirstValue(ClaimTypes.Role);

        if (email is null)
            throw new Exception("NotFound");

        return email;
    }
}
