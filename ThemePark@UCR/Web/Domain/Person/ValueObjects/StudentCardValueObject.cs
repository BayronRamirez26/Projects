using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects
{
    public class StudentCardValueObject
    {
        public string Value { get; }
        public static readonly StudentCardValueObject Invalid = new(string.Empty);

        public StudentCardValueObject(string value)
        {
            Value = value;
        }

        public static bool TryCreate(string? value, out StudentCardValueObject studentCard)
        {
            studentCard = Invalid;

            // Run validation
            if (string.IsNullOrWhiteSpace(value) || value.Length != 6)
            {
                return false;
            }

            if (!char.IsLetter(value[0]) || !char.IsUpper(value[0]))
            {
                return false;
            }

            for (int i = 1; i < value.Length; i++)
            {
                if (!char.IsDigit(value[i]))
                {
                    return false;
                }
            }

            // If validation passed, then return true and assign the name to the out parameter.
            // Otherwise, return false
            studentCard = new StudentCardValueObject(value);
            return true;
        }

        public static StudentCardValueObject Create(string studentCardValueObjectString)
        {
            var result = TryCreate(studentCardValueObjectString, out var studentCard);
            if (!result)
            {
                throw new ArgumentException("Invalid student card.");
            }
            return studentCard;
        }
    }
}
