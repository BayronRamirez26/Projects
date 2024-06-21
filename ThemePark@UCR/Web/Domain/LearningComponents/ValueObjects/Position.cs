using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
public class Position
{
    public Coordinate X { get; }
    public Coordinate Y { get; }
    public Coordinate Z { get; }

    private Position(Coordinate x, Coordinate y, Coordinate z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Position Create(double xValue, double yValue, double zValue)
    {
        Coordinate x;
        Coordinate y;
        Coordinate z;
        
            try
            {
                x = Coordinate.Create(xValue);
                y = Coordinate.Create(yValue);
                z = Coordinate.Create(zValue);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Invalid coordinate value.", ex);
            }
        
        return new Position(x, y, z);
    }
}
