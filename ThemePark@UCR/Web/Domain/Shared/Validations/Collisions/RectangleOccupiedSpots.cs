namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Validations.Collisions;

internal static partial class RectangleOccupiedSpots
{
    internal static List<Tuple<short, short>> GetRectangleOccupiedSpots(CollisionRectangle rectangle)
    {
        List<Tuple<short, short>> desiredSpots = new();

        if (rectangle.Rotation.Value == 0 || rectangle.Rotation.Value == 90 ||
            rectangle.Rotation.Value == 180 || rectangle.Rotation.Value == 270 ||
            rectangle.Rotation.Value == 360)
        {
            desiredSpots = GetOccupiedSpotsRightAngle(
                rectangle.VertexCNoRotationX, rectangle.VertexBNoRotationX,
                rectangle.VertexANoRotationY, rectangle.VertexDNoRotationY);
        }
        else if ((rectangle.Rotation.Value > 0 && rectangle.Rotation.Value < 90) 
            || (rectangle.Rotation.Value > 180 && rectangle.Rotation.Value < 270))
        {
            desiredSpots = GetOccupiedSpots(
                rectangle.VertexCX, rectangle.VertexCY, rectangle.VertexBX, rectangle.VertexBX,
                rectangle.VertexAX, rectangle.VertexAY, rectangle.VertexDX, rectangle.VertexDY);
        }
        else if ((rectangle.Rotation.Value > 90 && rectangle.Rotation.Value < 180) 
            || (rectangle.Rotation.Value > 270 && rectangle.Rotation.Value < 360))
        {
            desiredSpots = GetOccupiedSpots(
                rectangle.VertexDX, rectangle.VertexDY, rectangle.VertexAX, rectangle.VertexAX,
                rectangle.VertexCX, rectangle.VertexCY, rectangle.VertexBX, rectangle.VertexBY);
        }

        return desiredSpots;
    }
}
