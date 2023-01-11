using Grpc.Core;
using Grpc.Core.Interceptors;

namespace LibraryService.Interceptors
{
    public class ExceptionHandlerInterceptor : Interceptor
    {
        private readonly ILogger<ExceptionHandlerInterceptor> logger;

        public ExceptionHandlerInterceptor(ILogger<ExceptionHandlerInterceptor> logger)
        {
            this.logger=logger;
        }
        public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
           logger.LogInformation($"Starting receiving call. Type: {MethodType.Unary}. " +
           $"Method: {context.Method}.");

            try
            {
                return continuation(request, context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error thrown by {context.Method}.");
                throw;
            }

        }
    }
}
