using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;

/// <summary>
/// This represents the Templates entity in our system.
/// It contains some personal information about the template.
/// </summary>
public class Template_Has_Components
{
    /// <summary>
    /// This is the main constructor for the Templates entity.
    /// </summary>
    /// <param name="id">ID of the template</param>
    /// <param name="name">Name of the template</param>
    /// <param name="sizex">Size in the x direction</param>
    /// <param name="sizey">Size in the y direction</param>
    public Template_Has_Components(
        GuidWrapper id,
        MediumName component_type,
        GuidWrapper template,
        DoubleWrapper sizex,
        DoubleWrapper sizey,

        DoubleWrapper positionX,
        DoubleWrapper positionY,
        DoubleWrapper positionZ,

        DoubleWrapper rotationX,
        DoubleWrapper rotationY


        )
    {
        Id = id;
        Component_type = component_type;
        Template = template;
        SizeX = sizex;
        SizeY = sizey;
        PositionX = positionX;
        PositionY = positionY;
        PositionZ = positionZ;

        RotationX = rotationX;
        RotationY = rotationY;
    }

    internal Template_Has_Components() : this(
        new GuidWrapper(Guid.NewGuid()),
        new MediumName("Default Name"),
        new GuidWrapper(Guid.NewGuid()),
        new DoubleWrapper(0.0),
        new DoubleWrapper(0.0),
        new DoubleWrapper(0.0),
        new DoubleWrapper(0.0),
        new DoubleWrapper(0.0),
        new DoubleWrapper(0.0),
        new DoubleWrapper(0.0)
        )
    {

    }

    /// <summary>
    /// Gets the ID of the template.
    /// </summary>
    public GuidWrapper Id { get; }

    /// <summary>
    /// Gets the name of the template.
    /// </summary>
    public MediumName Component_type { get; }

    public GuidWrapper Template { get; }

    /// <summary>
    /// Gets the size of the template in the x direction.
    /// </summary>
    public DoubleWrapper SizeX { get; }

    /// <summary>
    /// Gets the size of the template in the y direction.
    /// </summary>
    public DoubleWrapper SizeY { get; }

    public DoubleWrapper PositionX { get; }

    public DoubleWrapper PositionY { get; }

    public DoubleWrapper PositionZ { get; }
    
    public DoubleWrapper RotationX { get; }
    public DoubleWrapper RotationY { get; }


}
