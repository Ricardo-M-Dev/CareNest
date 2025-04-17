namespace Application.Common.Mediator
{
    public class Mediator(IServiceProvider serviceProvider)
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            var handlerType = typeof(IRequestHandler<,>)
                .MakeGenericType(request.GetType(), typeof(TResponse));

            var handler = _serviceProvider.GetService(handlerType);

            if (handler == null)
                throw new InvalidOperationException($"Handler não encontrado para: {request.GetType().Name}");

            var method = handlerType.GetMethod("Handle");
            var task = (Task<TResponse>)method!.Invoke(handler, [request])!;
            return await task;
        }

    }
}
