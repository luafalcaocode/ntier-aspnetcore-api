using System.Text.RegularExpressions;

namespace alterdata.api.Shared.Formatters
{
    public static class SnakeCaseFormatters
    {
        public static string ToSnakeCase(this string value)
        {
            if (!string.IsNullOrEmpty(value))
                return Regex.Match(value, @"^_+") + Regex.Replace(value, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();

            return string.Empty;
        }
    }
}