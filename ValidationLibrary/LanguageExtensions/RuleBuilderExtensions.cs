using FluentValidation;
using System.Collections.Generic;

namespace ValidationLibrary.LanguageExtensions;
public static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, string> MatchPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        => ruleBuilder
            .Matches(@"^(1-)?\d{3}-\d{4}$")
            .WithMessage("Invalid phone number");

    public static IRuleBuilderOptions<T, string> NotStartWithWhiteSpace<T>(this IRuleBuilder<T, string> ruleBuilder) 
        => ruleBuilder
            .Must(m => m != null && !m.StartsWith(" "))
            .WithMessage("'{PropertyName}' should not start with whitespace");

    public static IRuleBuilderOptions<T, string> NotEndWithWhiteSpace<T>(this IRuleBuilder<T, string> ruleBuilder) 
        => ruleBuilder
            .Must(m => m != null && !m.EndsWith(" "))
            .WithMessage("'{PropertyName}' should not end with whitespace");
}
