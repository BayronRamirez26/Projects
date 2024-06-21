using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
public class Rotation
{
    public Angle X { get; }
    public Angle Y { get; }
    public Angle Z { get; }

    private Rotation(Angle x, Angle y, Angle z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Rotation Create(double xValue, double yValue, double zValue)
    {
        Angle x;
        Angle y;
        Angle z;

        try
        {
            x = Angle.Create(xValue);
            y = Angle.Create(yValue);
            z = Angle.Create(zValue);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException("Invalid angle value.", ex);
        }

        return new Rotation(x, y, z);
    }

}
