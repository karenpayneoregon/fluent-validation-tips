using FluentValidation;

namespace ValidateBirthDateApp.LanguageExtensions;


public static class RuleBuilderExtensions
{

    public static IRuleBuilderOptions<T, DateOnly> BirthDateRule<T>(this IRuleBuilder<T, DateOnly> ruleBuilder)
    {

        int minYear = DateTime.Now.AddYears(-120).Year;

        return ruleBuilder
            .Must(x => x.Year > minYear && x.Year <= DateTime.Now.Year)
            .WithMessage("'{PropertyName}'" + 
                         $" must be greater than {minYear} " +
                         $"year and less than or equal to {DateTime.Now.Year} ");
    }

}
