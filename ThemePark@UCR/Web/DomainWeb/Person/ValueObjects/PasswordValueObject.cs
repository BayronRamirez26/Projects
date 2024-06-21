using System.Text.Json.Serialization;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;

public class PasswordValueObject
{
    public string Value { get; }
    public const int MaxLength = 128;
    public const int MinLength = 8;
    public static readonly PasswordValueObject Invalid = new(String.Empty);

    // Allowed chars
    public static readonly char[] SpecialChars = "~`!@#$%^&*()_-+={[}]|:;\"'<,>.?/".ToCharArray();
    
    public PasswordValueObject(string value) { Value = value; }
    public static bool TryCreate(string? value, out PasswordValueObject passwordValueObject)
    {
        passwordValueObject = Invalid;
        if (string.IsNullOrWhiteSpace(value)) { return false; }
        if (value.Length > MaxLength || value.Length < MinLength) { return false; }

        // Verify that the password contains at least one special characte
        if (!value.Any(c => SpecialChars.Contains(c)))
        {
            return false;
        }

        passwordValueObject = new PasswordValueObject(value);
        return true;
    }

    public static PasswordValueObject Create(string passwordValueObjectString)
    {
        var result = TryCreate(passwordValueObjectString, out var passwordValueObject);
        if (!result)
        {
            throw new ArgumentException("Invalid name.");
        }

        return passwordValueObject;
    }
}
