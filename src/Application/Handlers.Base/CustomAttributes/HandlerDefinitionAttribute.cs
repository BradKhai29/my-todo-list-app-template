using System;

namespace Application.Handlers.Base.CustomAttributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class HandlerDefinitionAttribute : Attribute
{
    public Type RequestType { get; set; }

    public Type ResponseType { get; set; }
}
