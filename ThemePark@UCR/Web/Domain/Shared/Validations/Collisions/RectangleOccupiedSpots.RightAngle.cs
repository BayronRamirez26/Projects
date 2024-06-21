namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Validations.Collisions;

internal static partial class RectangleOccupiedSpots
{
    private static List<Tuple<short, short>> GetOccupiedSpotsRightAngle(
        double minX, double maxX,
        double minY, double maxY)
    {
        List<Tuple<short, short>> desiredSpots = new();

        for (short x = (short)Math.Floor(minX); x <= (short)Math.Ceiling(maxX); ++x)
        {
            for (short y = (short)Math.Floor(minY); y <= (short)Math.Ceiling(maxY); ++y)
            {
                desiredSpots.Add(new Tuple<short, short>(x, y));
            }
        }

        return desiredSpots;
    }
}
