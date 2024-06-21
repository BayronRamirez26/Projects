namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;

/// <summary>
/// Wrapper that allows to change double in Kiota generations
/// </summary>
public class DoubleWrapper : IDoubleWrapper
{
    /// <summary>
    /// Double value
    /// </summary>
    public double Value { get; }

    /// <summary>
    /// Primary constructor
    /// </summary>
    /// <param name="value">Double input neccesary to create</param>
    public DoubleWrapper(double value)
    {
        Value = value;
    }

    public static readonly DoubleWrapper Invalid = new(Double.PositiveInfinity);

    /// <summary>
    /// Check input double to validate if can be created
    /// </summary>
    /// <param name="inputValue">Double input neccesary to create</param>
    /// <returns>Bool response about if action is legal</returns>
    public static bool TryCreate(double inputValue, out DoubleWrapper doubleWrapper)
    {
        doubleWrapper = Invalid;
        if (inputValue == Double.PositiveInfinity)
        {
            return false;
        }
        doubleWrapper = new DoubleWrapper(inputValue);
        return true;
    }

    /// <summary>
    /// Create a new DoubleWrapper instance
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DoubleWrapper Create(double value)
    {
        return new DoubleWrapper(value);
    }
}
