namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

public class ShortName
{
    // TODO: add better check in TryCreate
    public string Value { get; }

    public static readonly char[] IllegalCharacters = { '/', '?', '!', '#', '@', '[', ']' };
    public const int MaxLenght = 10; // max lenght defined in the sql table

    public static readonly ShortName Invalid = new(string.Empty);

    public ShortName(string value)
    {
        // Run validation
        Value = value;
    }

    public static bool TryCreate(string? value, out ShortName shortName)
    {
        // Run validation.
        shortName = Invalid;
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
        shortName = new ShortName(value);
        return true;
    }

    public static ShortName Create(string? shortNameString)
    {
        var result = TryCreate(shortNameString, out var shortName);
        if (!result)
        {
            throw new ArgumentException("Invalid Short Name.");
        }
        return shortName;
    }
}
