namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

// LongName is used for multiple type such as CampusName or UniversityName and any other varchar[255]
public class LongName
{
    // TODO: add better check in TryCreate
    public string Value { get; }

    public static readonly char[] IllegalCharacters = { '/', '?', '!', '#', '@', '[', ']' };
    public const int MaxLenght = 255; // max lenght defined in the sql table

    public static readonly LongName Invalid = new(string.Empty);

    public LongName(string value)
    {
        // Run validation
        Value = value;
    }

    public static bool TryCreate(string? value, out LongName longName)
    {
        // Run validation.
        longName = Invalid;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.IndexOfAny(IllegalCharacters) != -1)
        {
            return false;
        }

        if (value.Length > MaxLenght)
        {
            return false;
        }
        // If validation passed, then return true and assign the Name to the out parameter.
        // Otherwise, return false
        longName = new LongName(value);
        return true;

    }

    public static LongName Create(string? longNameString)
    {
        var result = TryCreate(longNameString, out var longName);
        if (!result)
        {
            throw new ArgumentException("Invalid long name.");
        }
        return longName;
    }
}
