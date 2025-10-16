using System;
using Models.Application.Handlers.AppCode.Base;
using Models.Application.Handlers.AppCode.Common;

namespace Models.Application.Handlers.AppCode.Auth;

public class UserLoginAppCode : HandlerAppCode
{
    private UserLoginAppCode(int codeNumber) : base(codeNumber)
    {
    }

    protected override string AppCodePrefix => AppCodePrefixes.Auth.User.Login;

    public static readonly UserLoginAppCode EmailExisted = new(0);
    public static readonly UserLoginAppCode LoginSuccess = new(1);
}