using FluentValidation;
using MediatR;

namespace MedCS_2.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull where TResponse : class 
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0) 
            {
                var errors = failures.Select(f => f.ErrorMessage).ToList();

                // Return Response<T>.Fail for validation
                var responseType = typeof(TResponse);
                var response = Activator.CreateInstance(responseType);

                var props = responseType.GetProperties();
                props.FirstOrDefault(p => p.Name == "Succeeded")?.SetValue(response, false);
                props.FirstOrDefault(p => p.Name == "StatusCode")?.SetValue(response, 400);
                props.FirstOrDefault(p => p.Name == "Errors")?.SetValue(response, errors);
                props.FirstOrDefault(p => p.Name == "Message")?.SetValue(response, "Validation failed.");

                return (TResponse)response!;
            }
            return await next();
        }
    }
}
