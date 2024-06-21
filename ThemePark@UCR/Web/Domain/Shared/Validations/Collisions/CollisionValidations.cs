namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Validations.Collisions;

public class CollisionValidations
{
    public static bool RectangleCanBeCreatedOrModified(
        CollisionRectangle newRectangle, 
        IEnumerable<CollisionRectangle> existingRectangles, 
        CollisionSurface surface)
    {
        if (surface == null)
        {
            return false;
        }

        if (newRectangle.Length.Value <= 0 || newRectangle.Width.Value <= 0)
        {
            return false;
        }

        if (newRectangle.CenterX.Value < 0 || newRectangle.CenterX.Value > surface.SizeX.Value ||
            newRectangle.CenterY.Value < 0 || newRectangle.CenterY.Value > surface.SizeY.Value)
        {
            return false;
        }

        if (newRectangle.Rotation.Value < 0 || newRectangle.Rotation.Value >= 360)
        {
            return false;
        }

        if (!newRectangle.VertexesAreValid(surface.SizeX.Value, surface.SizeY.Value))
        {
            return false;
        }

        if (RectangleOverlapsWithOtherRectangles(newRectangle, existingRectangles))
        {
            return false;
        }

        return true;
    }

    private static bool RectangleOverlapsWithOtherRectangles(
        CollisionRectangle newRectangle,
        IEnumerable<CollisionRectangle> existingRectangles)
    {
        List<Tuple<short, short>> desiredSpots = RectangleOccupiedSpots.GetRectangleOccupiedSpots(newRectangle);

        List<List<Tuple<short, short>>> existingOccupiedSpots = new List<List<Tuple<short, short>>>();

        foreach (var existingRectangle in existingRectangles)
        {
            List<Tuple<short, short>> occupiedSpots = RectangleOccupiedSpots.GetRectangleOccupiedSpots(existingRectangle);
            existingOccupiedSpots.Add(occupiedSpots);
        }

        foreach (var existingSpots in existingOccupiedSpots)
        {
            foreach (var spot in desiredSpots)
            {
                for (int i = 0; i < existingSpots.Count; ++i)
                {
                    if (existingSpots[i].Item1 == spot.Item1 && existingSpots[i].Item2 == spot.Item2)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
