using System.Drawing;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Validations.Collisions;

public partial class CollisionRectangle
{
    public bool VertexesAreValid(double surfaceSizeX, double surfaceSizeY)
    {
        if (IsStraightRotation())
        {
            return ValidateVertexRange(VertexANoRotationX, VertexANoRotationY,
                    surfaceSizeX, surfaceSizeY) &&
                ValidateVertexRange(VertexBNoRotationX, VertexBNoRotationY,
                    surfaceSizeX, surfaceSizeY) &&
                ValidateVertexRange(VertexCNoRotationX, VertexCNoRotationY,
                    surfaceSizeX, surfaceSizeY) &&
                ValidateVertexRange(VertexDNoRotationX, VertexDNoRotationY,
                    surfaceSizeX, surfaceSizeY);
        }
        else
        {
            return ValidateVertexRange(VertexAX, VertexAY,
                    surfaceSizeX, surfaceSizeY) &&
                ValidateVertexRange(VertexBX, VertexBY,
                    surfaceSizeX, surfaceSizeY) &&
                ValidateVertexRange(VertexCX, VertexCY,
                    surfaceSizeX, surfaceSizeY) &&
                ValidateVertexRange(VertexDX, VertexDY,
                    surfaceSizeX, surfaceSizeY);
        }
    }

    private bool IsStraightRotation()
    {
        return Rotation.Value % 90 == 0;
    }

    private static bool ValidateVertexRange(double x, double y,
        double surfaceSizeX, double surfaceSizeY)
    {
        return x >= 0 && x <= surfaceSizeX &&
               y >= 0 && y <= surfaceSizeY;
    }
}
