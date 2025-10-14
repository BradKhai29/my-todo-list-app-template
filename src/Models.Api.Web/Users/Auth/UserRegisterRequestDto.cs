using System.Net;
using Models.Api.Web.Base;
using Models.Application.Handlers.Auth;
using Models.Application.Handlers.Base;

namespace Models.Api.Web.Users.Auth;

public class UserRegisterRequestDto : ApiRequestDto<UserRegisterRequest, UserRegisterResponseDto>
{
    public string Email { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public override UserRegisterRequest GetRequest()
    {
        return new UserRegisterRequest
        {
            Email = Email,
            Password = ConfirmPassword,
        };
    }

    public override UserRegisterResponseDto GetResponseDto(HandlerResponse handlerResponse)
    {
        var response = UserRegisterRequest.GetExactResponse(handlerResponse);

        return new UserRegisterResponseDto
        {
            HttpStatusCode = (int)HttpStatusCode.OK,
            IsSuccess = response.IsSuccess,
        };
    }
}