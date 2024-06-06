using System.Net;
using FluentValidation;

namespace DidarMessagingTask.Common.Filters;

class EndpointValidatorFilter<T> : IEndpointFilter
{
    private readonly IValidator<T> _validator;

    EndpointValidatorFilter(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        T inputData = context.GetArgument<T>(0);

        if (inputData is not null)
        {
            var validationResult = await _validator.ValidateAsync(inputData);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary(),
                    statusCode: (int)HttpStatusCode.UnprocessableEntity);
            }
        }

        return await next.Invoke(context);
    }
}

static class ValidatorExtensions
{
    internal static RouteHandlerBuilder Validator<T>(this RouteHandlerBuilder handlerBuilder)
        where T : class
    {
        handlerBuilder.AddEndpointFilter<EndpointValidatorFilter<T>>();
        return handlerBuilder;
    }
}