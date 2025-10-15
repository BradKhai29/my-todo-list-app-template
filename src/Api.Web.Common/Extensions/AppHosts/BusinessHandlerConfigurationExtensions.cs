using Application.Handlers.Base.Registry;
using Microsoft.Extensions.Hosting;
namespace Api.Web.Common.Extensions.AppHosts;

public static class BusinessHandlersConfigureExtensions
{
    /// <summary>
    ///     Specify to configure for this webApp instance to use
    ///     business handlers to execute business logic.
    /// </summary>
    /// <param name="webApp">
    ///     Web application instance to configure to use business handlers.
    /// </param>
    /// <returns>
    ///     Web application instance after configuring.
    /// </returns>
    public static IHost UseBusinessHandlers(this IHost webApp)
    {
        AppHandlerRequestRegistry.SetUp(webApp.Services);
        return webApp;
    }
}
