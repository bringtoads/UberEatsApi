using ErrorOr;
using FluentValidation;
using MediatR;

namespace UberEats.Application.Authentication.Commands.Behaviour
{
    public class ValidationBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse> 
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                return await next();
            }
            //var errors = validationResult.Errors
            //    .Select(validationFailure => Error.Validation(
            //        validationFailure.PropertyName,
            //        validationFailure.ErrorMessage))
            //    .ToList();
            // selecting and tolisting and convertall is same
            var errors = validationResult.Errors
             .ConvertAll(validationFailure => Error.Validation(
                 validationFailure.PropertyName,
                 validationFailure.ErrorMessage));
            // ***** see this need to fix this without using dynamic can throw run time error 
            return (dynamic)errors; 
        }
    }
}
