using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Validations.Collisions;

public class CollisionSurface
{
    public Size SizeX { get; set; }
    public Size SizeY { get; set; }

    public CollisionSurface(Size sizeX, Size sizeY)
    {
        SizeX = sizeX;
        SizeY = sizeY;
    }
}
