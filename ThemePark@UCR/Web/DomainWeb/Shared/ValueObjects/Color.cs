namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

public class Color
{
    public string Value { get; }

    public static Color Invalid => new(string.Empty);

    private Color(string value)
    {
        Value = value;
    }

    public static bool TryCreate(string? value, out Color color)
    {
        color = Invalid;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }
        else if (value.Length != 7 || value[0] != '#')
        {
            return false;
        }
        else if (!int.TryParse(value.Substring(1), System.Globalization.NumberStyles.HexNumber, null, out var _))
        {
            return false;
        }

        color = new Color(value);

        return true;
    }

    public static Color Create(string? colorValue)
    {
        var validation = TryCreate(colorValue, out var color);
        if (!validation)
        {
            throw new ArgumentException("Color value is invalid");
        }
        return color;
    }
}
