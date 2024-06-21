namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Validations.Collisions;

internal static partial class RectangleOccupiedSpots
{
    private static bool CheckLowerSegment(
        double vertexX1, double vertexY1,
        double vertexX2, double vertexY2,
        short x, short y)
    {
        double m = (vertexY2 - vertexY1) / (vertexX2 - vertexX1);
        double b = vertexY1 - m * vertexX1;

        return y >= m * x + b;
    }

    private static bool CheckLeftSegment(
        double vertexX1, double vertexY1,
        double vertexX2, double vertexY2,
        short x, short y)
    {
        double m = (vertexY2 - vertexY1) / (vertexX2 - vertexX1);
        double b = vertexY1 - m * vertexX1;

        return x >= (y - b) / m;
    }

    private static bool CheckUpperSegment(
        double vertexX1, double vertexY1,
        double vertexX2, double vertexY2,
        short x, short y)
    {
        double m = (vertexY2 - vertexY1) / (vertexX2 - vertexX1);
        double b = vertexY1 - m * vertexX1;
        --x;
        --y;

        return y <= m * x + b;
    }

    private static bool CheckRightSegment(
        double vertexX1, double vertexY1,
        double vertexX2, double vertexY2,
        short x, short y)
    {
        double m = (vertexY2 - vertexY1) / (vertexX2 - vertexX1);
        double b = vertexY1 - m * vertexX1;
        --x;
        --y;

        return x <= (y - b) / m;
    }
}
