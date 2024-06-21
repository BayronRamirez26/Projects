namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.ValueObjects;

//Learning Component Integer ID
public class LComponentID
{
    public int Value { get; }

    private static readonly LComponentID Invalid = new(-1);

    public const int MinValue = 0;
    public const int MaxValue = int.MaxValue;

    private LComponentID(int value)
    {
        Value = value;
    }

    public static bool TryCreate(int? value, out LComponentID integerValueObject)
    {
        integerValueObject = Invalid;

        if (!value.HasValue)
        {
            return false;
        }
        if (double.IsNaN(value.Value))
        {
            return false;
        }
        if (value.Value < MinValue || value.Value > MaxValue)
        {
            return false;
        }


        integerValueObject = new LComponentID(value.Value);
        return true;
    }

    public static LComponentID Create(int? value)
    {
        if (!TryCreate(value, out var integerValueObject))
        {
            throw new ArgumentException("Invalid integer Value.", nameof(value));
        }

        return integerValueObject;
    }
}