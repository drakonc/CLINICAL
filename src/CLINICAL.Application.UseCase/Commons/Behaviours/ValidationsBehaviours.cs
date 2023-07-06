using MediatR;
using FluentValidation;
using CLINICAL.Application.UseCase.Commons.Bases;
using ValidationException = CLINICAL.Application.UseCase.Commons.Exceptions.ValidationException;

namespace CLINICAL.Application.UseCase.Commons.Behaviours
{
    public class ValidationsBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationsBehaviours(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationsResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));
                var failures = validationsResults.Where( x => x.Errors.Any())
                                                 .SelectMany( x => x.Errors)
                                                 .Select( x => new BaseError() { PropertyName = x.PropertyName, ErrorMessage = x.ErrorMessage })
                                                 .ToList();
                if (failures.Any()) 
                {
                    throw new ValidationException(failures);
                }
            }

            return await next();
        }
    }
}
