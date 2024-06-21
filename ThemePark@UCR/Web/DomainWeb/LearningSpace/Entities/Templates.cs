using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;

/// <summary>
/// This represents the Templates entity in our system.
/// It contains some personal information about the template.
/// </summary>
public class Templates
{
    /// <summary>
    /// This is the main constructor for the Templates entity.
    /// </summary>
    /// <param name="id">ID of the template</param>
    /// <param name="name">Name of the template</param>
    /// <param name="sizex">Size in the x direction</param>
    /// <param name="sizey">Size in the y direction</param>
    /// <param name="sizez">Size in the z direction</param>
    /// <param name="floorColor">Color of the floor</param>
    /// <param name="ceilingColor">Color of the ceiling</param>
    /// <param name="wallsColor">Color of the walls</param>
    /// <param name="type">Type of the template</param>
    public Templates(Guid id,
        MediumName templateName,
        DoubleWrapper sizex,
        DoubleWrapper sizey,
        DoubleWrapper sizez,
        MediumName floorColor,
        MediumName ceilingColor,
        MediumName wallsColor,
        Guid type)
    {
        Id = id;
        TemplateName = templateName;
        SizeX = sizex;
        SizeY = sizey;
        SizeZ = sizez;
        FloorColor = floorColor;
        CeilingColor = ceilingColor;
        WallsColor = wallsColor;
        Type = type;
    }

    internal Templates() : this(
        Guid.NewGuid(),
        new MediumName("Default Name"),
        new DoubleWrapper(0.0),
        new DoubleWrapper(0.0),
        new DoubleWrapper(0.0),
        new MediumName("Default Floor Color"), // TODO: change to actual color
        new MediumName("Default Ceiling Color"), // TODO: change to actual color
        new MediumName("Default Walls Color"), // TODO: change to actual color
        Guid.NewGuid()
        )
    {

    }

    /// <summary>
    /// Gets the ID of the template.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the name of the template.
    /// </summary>
    public MediumName TemplateName { get; }

    /// <summary>
    /// Gets the size of the template in the x direction.
    /// </summary>
    public DoubleWrapper SizeX { get; }

    /// <summary>
    /// Gets the size of the template in the y direction.
    /// </summary>
    public DoubleWrapper SizeY { get; }

    /// <summary>
    /// Gets the size of the template in the z direction.
    /// </summary>
    public DoubleWrapper SizeZ { get; }

    /// <summary>
    /// Gets the color of the floor.
    /// </summary>
    public MediumName FloorColor { get; }

    /// <summary>
    /// Gets the color of the ceiling.
    /// </summary>
    public MediumName CeilingColor { get; }

    /// <summary>
    /// Gets the color of the walls.
    /// </summary>
    public MediumName WallsColor { get; }

    /// <summary>
    /// Gets the type of the template.
    /// </summary>
    public Guid Type { get; }
}
