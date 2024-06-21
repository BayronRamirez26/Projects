using System.Drawing;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Validations.Collisions;

public partial class CollisionRectangle
{
    public void InitializeVertexes()
    {
        double centerRotationX = GetCenterXWithRotation();
        double centerRotationY = GetCenterYWithRotation();

        VertexANoRotationX = CenterX.Value - Length.Value / 2;
        VertexANoRotationY = CenterY.Value - Width.Value / 2;
        VertexAX = GetVertexXWithRotation(
            VertexANoRotationX,
            VertexANoRotationY,
            centerRotationX);
        VertexAY = GetVertexYWithRotation(
            VertexANoRotationX,
            VertexANoRotationY,
            centerRotationY);

        VertexBNoRotationX = CenterX.Value + Length.Value / 2;
        VertexBNoRotationY = CenterY.Value - Width.Value / 2;
        VertexBX = GetVertexXWithRotation(
            VertexBNoRotationX,
            VertexBNoRotationY,
            centerRotationX);
        VertexBY = GetVertexYWithRotation(
            VertexBNoRotationX,
            VertexBNoRotationY,
            centerRotationY);

        VertexCNoRotationX = CenterX.Value - Length.Value / 2;
        VertexCNoRotationY = CenterY.Value + Width.Value / 2;
        VertexCX = GetVertexXWithRotation(
            VertexCNoRotationX,
            VertexCNoRotationY,
            centerRotationX);
        VertexCY = GetVertexYWithRotation(
            VertexCNoRotationX,
            VertexCNoRotationY,
            centerRotationY);

        VertexDNoRotationX = CenterX.Value + Length.Value / 2;
        VertexDNoRotationY = CenterY.Value + Width.Value / 2;
        VertexDX = GetVertexXWithRotation(
            VertexDNoRotationX,
            VertexDNoRotationY,
            centerRotationX);
        VertexDY = GetVertexYWithRotation(
            VertexDNoRotationX,
            VertexDNoRotationY,
            centerRotationY);
    }
}
