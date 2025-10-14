using System;

namespace Application.Handlers.Base.Exceptions;

/// <summary>
///     Support exception to provide detail error for the request registry setup.
/// </summary>
public class HandlerRequestRegistrySetupException : Exception
{
    private HandlerRequestRegistrySetupException(string message) : base(message)
    {
    }

    /// <summary>
    ///     Throws this exception when the target handler type does not define the <see cref="Common.HandlerDefinitionAttribute"/>.
    /// </summary>
    /// <param name="handlerType"> Handler type that has exception. </param>
    public static HandlerRequestRegistrySetupException HandlerDefinitionNotFound(Type handlerType)
    {
        return new HandlerRequestRegistrySetupException($"Handler [{handlerType.Name}] does not define its HandlerDefinitionAttribute");
    }

    /// <summary>
    ///     Throws this exception when the target request type cannot find its business handler.
    /// </summary>
    /// <param name="requestType"> Request type that has exception. </param>
    public static HandlerRequestRegistrySetupException CannotFindHandlerForRequest(Type requestType)
    {
        return new HandlerRequestRegistrySetupException($"No business handler found for request [{requestType.Name}]");
    }

    /// <summary>
    ///     Throws this exception when the target request type already handled by existed business handler.
    /// </summary>
    /// <param name="requestType"> Request type that has exception. </param>
    public static HandlerRequestRegistrySetupException HandlerWithSameRequest(Type requestType)
    {
        return new HandlerRequestRegistrySetupException($"Existed another handler handle same request [{requestType.Name}]");
    }
}