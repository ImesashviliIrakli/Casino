using BuildingBlocks.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Users.Api.Controllers;

public class BaseController : ControllerBase
{
    public IActionResult CreateResponse<T>(Result<T> result)
    {
        if (result.IsSuccess)
            return Ok(result.Value);

        switch (result.Error.Code) 
        {
            case "NotFound":
                return NotFound(result.Error);
            case "LoginFailed":
                return BadRequest(result.Error);
                default: return BadRequest(result.Error);
        }
    }
}
