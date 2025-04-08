namespace Application.Common.Mediator
{
    public class Mediator(IServiceProvider serviceProvider)
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            var handlerType = typeof(IRequestHandler<,>)
                .MakeGenericType(request.GetType(), typeof(TResponse));

            var handler = _serviceProvider.GetService(handlerType);

            if (handler == null)
                throw new InvalidOperationException($"Handler não encontrado para o request {request.GetType().Name}");

            return (TResponse) handlerType
                .GetMethod("Handle")!
                .Invoke(handler, [request])!;
        }
    }
}
