namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

/// <summary>
/// Represents a counter value object which is a tiny integer in SQL.
/// The minimum value is 0 and the maximum value is 255.
/// </summary>
public class Counter
{
    public byte Value { get; private set; }

    // min value is 0
    public static Counter Invalid => new(byte.MinValue);

    public const byte MinValue = byte.MinValue;
    public const byte MaxValue = byte.MaxValue;

    private Counter(byte value)
    {
        Value = value;
    }

    public static bool TryCreate(byte? value, out Counter counterOutput)
    {
        // Run validation.
        counterOutput = Invalid;
        if (!value.HasValue)
        {
            return false;
        }
        if (value < MinValue || value > MaxValue)
        {
            return false;
        }

        counterOutput = new Counter(value.Value);

        return true;
    }

    public static Counter Create(byte? counterValue)
    {
        var validation = TryCreate(counterValue, out var counterOutput);
        if (!validation)
        {
            throw new ArgumentException("Invalid counter.");
        }
        return counterOutput;
    }
}
