using System.Drawing;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Validations.Collisions;

public partial class CollisionRectangle
{
    public double VertexAX { get; set; }
    public double VertexAY { get; set; }
    public double VertexBX { get; set; }
    public double VertexBY { get; set; }
    public double VertexCX { get; set; }
    public double VertexCY { get; set; }
    public double VertexDX { get; set; }
    public double VertexDY { get; set; }
    public double VertexANoRotationX { get; set; }
    public double VertexANoRotationY { get; set; }
    public double VertexBNoRotationX { get; set; }
    public double VertexBNoRotationY { get; set; }
    public double VertexCNoRotationX { get; set; }
    public double VertexCNoRotationY { get; set; }
    public double VertexDNoRotationX { get; set; }
    public double VertexDNoRotationY { get; set; }
}
