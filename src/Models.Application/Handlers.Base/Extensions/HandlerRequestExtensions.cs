using System.Threading;
using System.Threading.Tasks;
using Models.Application.Handlers.Base.Registry;

namespace Models.Application.Handlers.Base;

// public static class HandlerRequestExtensions
// {
//     public static Task<HandlerResponse> HandleAsync<TRequest>(this TRequest request, CancellationToken ct)
//         where TRequest : HandlerRequest
//     {
//         return HandlerRequestRegistry.Instance.ResolveAsync(request, ct);
//     }
// }
