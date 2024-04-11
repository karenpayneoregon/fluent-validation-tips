using CountryValidation;
using FluentValidation;

namespace TaxpayerValidation.LanguageExtensions;


public static class RuleBuilderExtensions
{
    /// <summary>
    /// Custom rule for a date
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    /// <param name="ruleBuilder">Build from caller</param>
    public static IRuleBuilderOptions<T, DateOnly> BirthDateRule<T>(this IRuleBuilder<T, DateOnly> ruleBuilder)
    {

        int minYear = DateTime.Now.AddYears(-120).Year;

        return ruleBuilder
            .Must(x => x.Year > minYear && x.Year <= DateTime.Now.Year)
            .WithMessage("'{PropertyName}'" +
                         $" must be greater than {minYear} " +
                         $"year and less than or equal to {DateTime.Now.Year} ");
    }


    public static IRuleBuilderOptions<T, string> SsnRule<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        CountryValidator validator = new();
        return ruleBuilder
            .Must(ssn => validator.ValidateNationalIdentityCode(ssn, Country.US).IsValid)
            .WithMessage("'{PropertyName}'" +
                         $" is invalid");
    }


}
