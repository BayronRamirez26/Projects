using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Validations.Collisions;

public partial class CollisionRectangle
{
    private double GetCenterXWithRotation()
    {
        return CenterX.Value
            - (CenterX.Value * Math.Cos(Rotation.Value)
            - CenterY.Value * Math.Sin(Rotation.Value));
    }

    private double GetCenterYWithRotation()
    {
        return CenterY.Value
            - (CenterX.Value * Math.Sin(Rotation.Value)
            + CenterY.Value * Math.Cos(Rotation.Value));
    }

    private double GetVertexXWithRotation(
        double vertexXNoRotation,
        double vertexYNoRotation,
        double centerRotationX)
    {
        return vertexXNoRotation * Math.Cos(Rotation.Value)
            - vertexYNoRotation * Math.Sin(Rotation.Value)
            + centerRotationX;
    }

    private double GetVertexYWithRotation(
        double vertexXNoRotation,
        double vertexYNoRotation,
        double centerRotationY)
    {
        return vertexXNoRotation * Math.Sin(Rotation.Value)
            + vertexYNoRotation * Math.Cos(Rotation.Value)
            + centerRotationY;
    }
}
