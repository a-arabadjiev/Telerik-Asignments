using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Helpers
{
    public class ValidationHelper
    {
        private const string InvalidNumberOfArguments = "Invalid number of arguments. Expected: {0}; received: {1}.";
        private const string InvalidLengthErrorMessage = "{0} should be between {1} and {2} symbols.";
        private const string NegativeNumberErrorMessage = "{0} cannot be negative.";
        private const string InvalidEnumValueErrorMessage = "{1} must be {2}.";
        private const string StringCannotBeNullErrorMessage = "{0} cannot be null.";

        public static void ValidateIntRange(int minLength, int maxLength, int actualLength, string field)
        {
            if (actualLength < minLength || actualLength > maxLength)
            {
                throw new ArgumentOutOfRangeException(string.Format(InvalidLengthErrorMessage, field, minLength, maxLength));
            }
        }

        public static void ValidateStringLength(string stringToValidate, int minLength, int maxLength)
        {
            ValidateIntRange(minLength, maxLength, stringToValidate.Length, stringToValidate);
        }

        public static void ValidateStringNotNull(string stringToValidate, string field)
        {
            if (stringToValidate == null)
            {
                throw new ArgumentNullException(string.Format(StringCannotBeNullErrorMessage, field));
            }
        }

        public static void ValidateArgumentsCount(IList<string> list, int expectedNumberOfParameters)
        {
            if (list.Count != expectedNumberOfParameters)
            {
                throw new ArgumentException(string.Format(InvalidNumberOfArguments, expectedNumberOfParameters, list.Count));
            }

        }

        public static void ValidateNonNegative(decimal value, string field)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format(NegativeNumberErrorMessage, field));
            }
        }

        public static void ValidateEnumValue(int enumIndex, Type type)
        {
            List<string> enumNames = Enum.GetNames(type).ToList();

            int enumMinValue = 0;
            int enumMaxValue = enumNames.Count - 1;

            enumNames[enumMaxValue] = "or " + enumNames[enumMaxValue];

            if (enumIndex < enumMinValue || enumIndex > enumMaxValue) 
            {
                throw new ArgumentOutOfRangeException(string.Format(InvalidEnumValueErrorMessage, type.Name, string.Join(", ", enumNames)));
            }
        }
    }
}
