using Application.Handlers.Common;

namespace Application.Handlers.Base;

public static class BusinessHandlerExtensions
{
    private static readonly Type comparedType = typeof(HandlerDefinitionAttribute);
    public static Type GetHandlerRequestType(this Type handlerType)
    {
        var attributes = handlerType.GetCustomAttributes(true);
        var handlerDefinition = attributes.FirstOrDefault(type => type.GetType().Equals(comparedType)) as HandlerDefinitionAttribute;

        return handlerDefinition!.RequestType;
    }
}
