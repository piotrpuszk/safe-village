using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Dynamic;

namespace SafeVillage.SharedKernel;
public class MediatorHandlerLoggingBehavior<TRequest, TResponse>
    (ILogger<MediatorHandlerLoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestType = request.GetType().Name;
        var requestArguments = GetArguments(request);

        logger.LogInformation("[Mediator][Handler] Start handling request {request} with arguments: {arguments}", requestType, requestArguments);
        var watch = Stopwatch.StartNew();

        TResponse response;

        try
        {
            response = await next(cancellationToken);
        }
        catch
        {
            watch.Stop();
            logger.LogError("[Mediator][Handler] Finish with ERROR handling request {request}. Time elapsed: {elapsed} ms", requestType, watch.ElapsedMilliseconds);
            throw;
        }

        watch.Stop();

        logger.LogInformation("[Mediator][Handler] Finish handling request {request}. Time elapsed: {elapsed} ms", requestType, watch.ElapsedMilliseconds);

        return response;
    }

    private object GetArguments(TRequest request)
    {
        var properties = request.GetType().GetProperties();

        var result = new ExpandoObject() as IDictionary<string, object?>;

        foreach (var property in properties)
        {
            result.Add(property.Name, property.GetValue(request));  
        }

        return result;
    }
}
