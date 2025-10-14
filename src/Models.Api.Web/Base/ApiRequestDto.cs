using Models.Application.Handlers.Base;

namespace Models.Api.Web.Base;

/// <summary>
///     Base class for all DTO classes received from the API.
/// </summary>
/// <typeparam name="TRequest">
///     HandlerRequest type that contains the business data needed to execute the logic.
/// </typeparam>
/// <typeparam name="TResponseDto">
///     The specific DTO class used to format and send the final result back to the client.
/// </typeparam>
public abstract class ApiRequestDto<TRequest, TResponseDto>
    where TRequest : HandlerRequest
    where TResponseDto : ApiResponseDto
{
    /// <summary>
    ///     Converts DTO object into the internal business request object.
    /// </summary>
    /// <returns>
    ///     The specific HandlerRequest object that will be handled by the business handler.
    /// </returns>
    public abstract TRequest GetRequest();

    /// <summary>
    ///     Converts the HandlerResponse object back into the specific response DTO format.
    /// </summary>
    /// <param name="handlerResponse">
    ///     The raw response object returned by the business handler.
    /// </param>
    /// <returns>
    ///     Response DTO object, ready to be sent back to API's final output.
    /// </returns>
    public abstract TResponseDto GetResponseDto(HandlerResponse handlerResponse);
}
