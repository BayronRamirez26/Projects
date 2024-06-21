namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;

public class InstitutionalEmailValueObject
{
    public string Value { get; }
    public static readonly InstitutionalEmailValueObject Invalid = new(string.Empty);

    public InstitutionalEmailValueObject(string value)
    {
        Value = value;
    }

    public static bool TryCreate(string? value, out InstitutionalEmailValueObject institutionalEmail)
    {
        institutionalEmail = Invalid;

        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (!value.EndsWith("@ucr.ac.cr"))
        {
            return false;
        }

        // Additional email validation logic if necessary
        if (!value.Contains('@') || !value.Contains('.'))
        {
            return false;
        }

        institutionalEmail = new InstitutionalEmailValueObject(value);
        return true;
    }

    public static InstitutionalEmailValueObject Create(string emailString)
    {
        var result = TryCreate(emailString, out var institutionalEmail);
        if (!result)
        {
            throw new ArgumentException("Invalid institutional email address.");
        }
        return institutionalEmail;
    }
}
