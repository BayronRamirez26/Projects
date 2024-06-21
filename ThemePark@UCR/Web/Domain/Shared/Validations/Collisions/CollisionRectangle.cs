using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Validations.Collisions;

public partial class CollisionRectangle
{
    public CollisionRectangle(Coordinate centerX, Coordinate centerY, Size length, Size width, Angle rotation)
    {
        CenterX = centerX;
        CenterY = centerY;
        Length = length;
        Width = width;
        Rotation = rotation;
        InitializeVertexes();
    }

    public Coordinate CenterX { get; set; }
    public Coordinate CenterY { get; set; }
    public Size Length { get; set; }
    public Size Width { get; set; }
    public Angle Rotation { get; set; }
}
