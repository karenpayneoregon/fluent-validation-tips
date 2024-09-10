using FluentLibrary.Models;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using static ConsoleConfigurationLibrary.Classes.Configuration;
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace FluentLibrary.LanguageExtensions;
public static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, DateOnly> BirthDateRule<T>(this IRuleBuilder<T, DateOnly> ruleBuilder)
    {
        var section = JsonRoot().GetSection(nameof(DateOnlyConfiguration));
        var minYear = DateTime.Now.AddYears(section.Get<DateOnlyConfiguration>()!.MinYear).Year;

        return ruleBuilder
            .Must(x => x.Year > minYear && x.Year <= DateTime.Now.Year)
            .WithMessage($"Birth date must be greater than {minYear} " +
                         $"year and less than or equal to {DateTime.Now.Year} ");
    }

    public static IRuleBuilderOptions<T, string> FullName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .MinimumLength(10)
            .Must(val => val.Split(" ").Length >= 2);
    }

    public static IRuleBuilderOptions<T, FormattableString> FullName<T>(this IRuleBuilder<T, FormattableString> ruleBuilder)
    {
        return ruleBuilder
            .Must(x => x.ArgumentCount == 2)
            .Must(x => 
            x.GetArgument(0).ToString()?.Length is <= 10 and >= 1 &&
            x.GetArgument(1).ToString()?.Length is <= 20 and >= 1);
    }

}

