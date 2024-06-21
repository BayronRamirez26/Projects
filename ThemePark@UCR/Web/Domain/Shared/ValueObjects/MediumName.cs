﻿namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

// LongName is used for multiple type such as CampusName or UniversityName and any other varchar[255]
public class MediumName : IMediumName
{
    // TODO: add better check in TryCreate
    public string Value { get; }

    public static readonly char[] IllegalCharacters = { '/', '?', '!', '@', '[', ']' };
    public const int MaxLenght = 127; // max lenght defined in the sql table

    public static readonly MediumName Invalid = new(string.Empty);

    public MediumName(string value)
    {
        // Run validation
        Value = value;
    }

    public static bool TryCreate(string? value, out MediumName mediumName)
    {
        // Run validation.
        mediumName = Invalid;
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
        mediumName = new MediumName(value);
        return true;

    }

    public static MediumName Create(string? mediumNameString)
    {
        var result = TryCreate(mediumNameString, out var mediumName);
        if (!result)
        {
            throw new ArgumentException("Invalid medium name.");
        }
        return mediumName;
    }
}
