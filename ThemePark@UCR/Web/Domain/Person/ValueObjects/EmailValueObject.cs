
namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;

public class EmailValueObject
{
    public string Value { get; }
    public EmailValueObject(string value)
    {
        Value = value;
    }

    public static EmailValueObject Invalid => new(string.Empty);
    public static bool TryCreate(string? value, out EmailValueObject email)
    {
        email = Invalid;

        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        // TODO: Implement a more robust email validation
        if (!value.Contains('@') || !value.Contains('.'))
        {
            return false;
        }

        email = new EmailValueObject(value);
        return true;
    }

    public static EmailValueObject Create(string emailString)
    {
        var result = TryCreate(emailString, out var email);
        // System.Diagnostics.Debug.WriteLine(email.Value);
        if (!result)
        {
            throw new ArgumentException("Invalid name.");
        }

        return email;
    }
}

