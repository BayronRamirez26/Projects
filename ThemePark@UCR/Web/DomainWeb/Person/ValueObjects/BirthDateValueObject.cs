using System.Text.Json.Serialization;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects
{
    public class BirthDateValueObject
    {
        public DateOnly? Value { get; }

        public static readonly BirthDateValueObject Invalid = new(DateOnly.MinValue);

        [JsonConstructor]
        public BirthDateValueObject(DateOnly? value)
        {
            if (value.HasValue && value.Value <= DateOnly.FromDateTime(DateTime.Now))
            {
                Value = value;
            }
            else
            {
                Value = DateOnly.MinValue;
            }
        }

        public static bool TryCreate(DateOnly? value, out BirthDateValueObject birthDate)
        {

            birthDate = Invalid;


            if (!value.HasValue || value.Value > DateOnly.FromDateTime(DateTime.Now))
            {
                return false;
            }


            birthDate = new BirthDateValueObject(value.Value);
            return true;
        }

        public static BirthDateValueObject Create(DateOnly? birthDateValue)
        {

            var result = TryCreate(birthDateValue, out var birthDate);
            if (!result)
            {

                throw new ArgumentException("Invalid birth date.");
            }
            return birthDate;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (BirthDateValueObject)obj;
            return Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.HasValue ? Value.Value.ToString("dd-MM-yyyy") : string.Empty;
        }

        public static implicit operator DateOnly?(BirthDateValueObject birthDateValueObject)
        {
            return birthDateValueObject.Value;
        }

        public static explicit operator BirthDateValueObject(DateOnly dateTime)
        {
            return Create(dateTime);
        }
    }
}

