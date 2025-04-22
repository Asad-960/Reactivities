using FluentValidation;
using MediatR;

namespace Application.Core;

public class ValidationBehavior<TRequest, TResoponse>
    : IPipelineBehavior<TRequest, TResoponse> where TRequest : notnull
{
    private readonly IValidator<TRequest>? validator;
    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        this.validator = validator;
    }
    
    public async Task<TResoponse> Handle(TRequest request, RequestHandlerDelegate<TResoponse> next, CancellationToken cancellationToken)
    {
        if (validator == null) return await next();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        return await next();
    }
}
