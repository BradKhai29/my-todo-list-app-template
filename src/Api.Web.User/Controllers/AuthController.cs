using System.Net.Mime;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Models.Api.Web.Users.Auth;
using Models.Application.Handlers.Auth;

namespace Api.Web.User.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> LoginAsync(UserLoginRequestDto loginDto, CancellationToken ct)
    {
        UserLoginRequest handlerRequest = loginDto.GetRequest();
        var handlerResponse = await handlerRequest.HandleAsync(ct);

        // Resolve for the correct status code and the correct response detail.
        var responseDto = loginDto.GetResponseDto(handlerResponse);
        return StatusCode(responseDto.HttpStatusCode, responseDto);
    }

    [HttpPost("register")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> RegisterAsync(UserRegisterRequestDto registerDto, CancellationToken ct)
    {
        UserRegisterRequest handlerRequest = registerDto.GetRequest();
        var handlerResponse = await handlerRequest.HandleAsync(ct);

        // Resolve for the correct status code and the correct response detail.
        var responseDto = registerDto.GetResponseDto(handlerResponse);
        return StatusCode(responseDto.HttpStatusCode, responseDto);
    }
}