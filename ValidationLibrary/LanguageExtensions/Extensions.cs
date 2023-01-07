using FluentValidation;
using System.Collections.Generic;

namespace ValidationLibrary.LanguageExtensions;
public static class Extensions
{
    public static IRuleBuilderOptions<T, string> MatchPhoneNumber<T>(this IRuleBuilder<T, string> rule)
        => rule.Matches(@"^(1-)?\d{3}-\d{4}$").WithMessage("Invalid phone number");
}
