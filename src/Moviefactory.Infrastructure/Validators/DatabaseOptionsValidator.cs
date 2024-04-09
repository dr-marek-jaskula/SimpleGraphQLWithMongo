using Microsoft.Extensions.Options;
using Moviefactory.Domain.Common.Utilities;
using Moviefactory.Infrastructure.Options;

namespace Moviefactory.Infrastructure.Validators;

public sealed class DatabaseOptionsValidator : IValidateOptions<DatabaseOptions>
{
    public ValidateOptionsResult Validate(string? name, DatabaseOptions options)
    {
        var validationResult = string.Empty;

        if (options.ConnectionString.IsNullOrEmptyOrWhiteSpace())
        {
            validationResult += "Connection string is missing. ";
        }

        if (options.DatabaseName.IsNullOrEmptyOrWhiteSpace())
        {
            validationResult += "Retry delay is less than one. ";
        }

        if (options.CollectionName.IsNullOrEmptyOrWhiteSpace())
        {
            validationResult += "Retry Count is less than one. ";
        }

        if (!validationResult.IsNullOrEmptyOrWhiteSpace())
        {
            return ValidateOptionsResult.Fail(validationResult);
        }

        return ValidateOptionsResult.Success;
    }
}