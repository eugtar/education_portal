using System.Globalization;
using FluentValidation;

namespace Web.Validators.RuleBuilderExtensions;

public static class FluentValidatorExtension
{
    public static IRuleBuilderOptions<T, string?> MustBeDateTimeOfFormat<T>(this IRuleBuilder<T, string?> ruleBuilder, string format)
    {
        return ruleBuilder.Must(
            str =>
            {
                if (str is null) return true;
                return DateTime.TryParseExact(str, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
            }
        );
    }

    public static IRuleBuilderOptions<T, string?> MustBeTimeOfFormat<T>(this IRuleBuilder<T, string?> ruleBuilder, string format)
    {
        return ruleBuilder.Must(
            str =>
            {
                if (str is null) return true;
                return TimeOnly.TryParseExact(str, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
            }
        );
    }
}
