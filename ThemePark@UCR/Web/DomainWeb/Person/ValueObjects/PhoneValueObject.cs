namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;

public class PhoneValueObject
{
    public string Value { get; }
    public const int MaxLength = 20;
    public PhoneValueObject(string value)
    {
        Value = value;
    }

    public static PhoneValueObject Invalid => new(string.Empty);
    public static bool TryCreate(string? value, out PhoneValueObject phoneNumber)
    {
        phoneNumber = Invalid;

        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.Length > MaxLength)
        {
            throw new ArgumentException($"Phone number cannot be longer than {MaxLength} characters.", nameof(phoneNumber));
        }

        phoneNumber = new PhoneValueObject(value);

        return true;
    }

    public static PhoneValueObject Create(string personPhoneValueObjectString)
    {
        var result = TryCreate(personPhoneValueObjectString, out var phoneNumber);
        if (!result)
        {
            throw new ArgumentException("Invalid name.");
        }
        Console.WriteLine(phoneNumber.Value);
        return phoneNumber;
    }
}
