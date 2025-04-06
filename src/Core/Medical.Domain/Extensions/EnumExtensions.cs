using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Medical.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayDescription(this Enum enumValue, Func<string, string> translationFunction = null)
        {
            var enumValueAsString = enumValue.ToString();
            var val = enumValue.GetType().GetMember(enumValueAsString).FirstOrDefault();
            var enumVal = val?.GetCustomAttribute<DisplayAttribute>()?.GetDescription() ?? enumValueAsString;

            if (translationFunction != null)
                return translationFunction(enumVal);

            return enumVal;
        }

    }
}
