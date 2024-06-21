namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

public class Size
{
    public double Value { get; }
    private Size(double value)
    {
        Value = value;
    }

    public static Size Invalid => new(double.NaN);

    public static bool TryCreate(double? value, out Size sizeOutput)
    {
        sizeOutput = Invalid;

        if (!value.HasValue)
        {
            return false;
        }
        if (double.IsNaN(value.Value))
        {
            return false;
        }
        if (value.Value < 0)
        {
            return false;
        }
        if (double.IsInfinity(value.Value))
        {
            return false;
        }

        sizeOutput = new Size(value.Value);

        return true;
    }

    public static Size Create(double? value)
    {
        var validation = TryCreate(value, out var sizeOutput);
        if (!validation)
        {
            throw new ArgumentException("Invalid size.");
        }
        return sizeOutput;
    }
}
