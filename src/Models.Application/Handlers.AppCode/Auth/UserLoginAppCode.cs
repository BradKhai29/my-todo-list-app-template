using System;
using System.Net;
using Models.Application.Handlers.AppCode.Base;
using Models.Application.Handlers.AppCode.Common;

namespace Models.Application.Handlers.AppCode.Auth;

public class UserLoginAppCode : HandlerAppCode
{
    protected override string AppCodePrefix => AppCodePrefixes.Auth.User.Login;

    private UserLoginAppCode(int codeNumber, HttpStatusCode httpStatusCode)
        : base(codeNumber, httpStatusCode)
    {
    }

    public static readonly UserLoginAppCode EmailNotExisted = new(0, HttpStatusCode.NotFound);
    public static readonly UserLoginAppCode LoginSuccess = new(1, HttpStatusCode.OK);
    public static readonly UserLoginAppCode IncorrectPassword = new(2, HttpStatusCode.BadRequest);
}