namespace Models.Api.Web.Base;

/// <summary>
///     Base class for any api response dto classes to extend from.
/// </summary>
public abstract class ApiResponseDto
{
    /// <summary>
    ///     HTTP response status code return with this DTO.
    /// </summary>
    public int HttpStatusCode { get; set; }
}