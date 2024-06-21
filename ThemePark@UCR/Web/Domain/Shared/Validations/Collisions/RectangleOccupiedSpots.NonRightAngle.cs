namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Validations.Collisions;

internal static partial class RectangleOccupiedSpots
{
    private static List<Tuple<short, short>> GetOccupiedSpots(
        double vertexMinXCoordinateX, double vertexMinXCoordinateY,
        double vertexMaxXCoordinateX, double vertexMaxXCoordinateY,
        double vertexMinYCoordinateX, double vertexMinYCoordinateY,
        double vertexMaxYCoordinateX, double vertexMaxYCoordinateY)
    {
        // If MinX is greater than MaxX, swap them
        if (vertexMinXCoordinateX > vertexMaxXCoordinateX)
        {
            Swap(ref vertexMinXCoordinateX, ref vertexMaxXCoordinateX);
        }
        // If MinY is greater than MaxY, swap them
        if (vertexMinYCoordinateY > vertexMaxYCoordinateY)
        {
            Swap(ref vertexMinYCoordinateY, ref vertexMaxYCoordinateY);
        }

        List<Tuple<short, short>> desiredSpots = new();

        for (short x = (short)Math.Floor(vertexMinXCoordinateX);
            x <= (short)Math.Ceiling(vertexMaxXCoordinateX) + 1; ++x)
        {
            for (short y = (short)Math.Floor(vertexMinYCoordinateY);
                y <= (short)Math.Ceiling(vertexMaxYCoordinateY) + 1; ++y)
            {
                if (CheckLowerSegment(vertexMinYCoordinateX, vertexMinYCoordinateY,
                    vertexMinXCoordinateX, vertexMinXCoordinateY, x, y) &&
                    CheckLowerSegment(vertexMinYCoordinateX, vertexMinYCoordinateY,
                    vertexMaxXCoordinateX, vertexMaxXCoordinateY, x, y) &&
                    CheckUpperSegment(vertexMaxYCoordinateX, vertexMaxYCoordinateY,
                    vertexMinXCoordinateX, vertexMinXCoordinateY, x, y) &&
                    CheckUpperSegment(vertexMaxYCoordinateX, vertexMaxYCoordinateY,
                    vertexMaxXCoordinateX, vertexMaxXCoordinateY, x, y))
                {
                    desiredSpots.Add(new Tuple<short, short>(x, y));
                }
            }
        }

        return desiredSpots;
    }

    private static void Swap(ref double a, ref double b)
    {
        double temp = a;
        a = b;
        b = temp;
    }
}
