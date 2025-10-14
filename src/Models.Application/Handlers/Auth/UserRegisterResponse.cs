using Models.Application.Handlers.Base;

namespace Models.Application.Handlers.Auth;

public class UserRegisterResponse : HandlerResponse
{
    public bool IsSuccess { get; set; }
}