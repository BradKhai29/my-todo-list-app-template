using System;

namespace Application.Handlers.Common;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class HandlerDefinitionAttribute : Attribute
{
    public Type RequestType { get; set; }

    public Type ResponseType { get; set; }
}
