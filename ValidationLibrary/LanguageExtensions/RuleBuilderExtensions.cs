using FluentValidation;


namespace ValidationLibrary.LanguageExtensions;
public static class RuleBuilderExtensions
{
    /// <summary>
    /// Matches a specific phone number pattern nnn-nnnn
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ruleBuilder"></param>
    /// <returns></returns>
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

    public static IRuleBuilderOptions<T, DateOnly> BirthDateRule<T>(this IRuleBuilder<T, DateOnly> ruleBuilder)
    {
        int minYear = DateTime.Now.AddYears(-100).Year;
        return ruleBuilder
            .Must(x => x.Year > minYear && x.Year <= DateTime.Now.Year)
            .WithMessage($"Birth date must be greater than {minYear} " +
                         $"year and less than or equal to {DateTime.Now.Year} ");
    }

}
