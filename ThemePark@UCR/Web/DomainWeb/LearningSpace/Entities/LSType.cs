using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
/// <summary>
/// This represents the User entity in our system.
/// It contains some personal information about the learningSpace.
/// </summary>
public class LSType
{
    /// <summary>
    /// This is the main constructor for the LearningSpaces entity
    /// </summary>
    /// <param name="universityName">Full name of the university</param>
    /// <param name="campusName">Full name of the campus</param>
    /// <param name="siteName">Medium name of the site</param>
    /// <param name="buildingAcronym">Acronym of the building</param>
    /// <param name="levelNumber">Level number</param>
    /// <param name="learningSpaceID">ID of the learning space</param>
    /// <param name="learningSpaceName">Name of the learning space</param>
    /// <param name="name">Short name of the learning space</param>
    /// <param name="sizex">Size in the x direction</param>
    /// <param name="sizey">Size in the y direction</param>
    /// <param name="sizez">Size in the z direction</param>
    /// <param name="floorAssetId">ID of the floor asset</param>
    /// <param name="ceilingAssetId">ID of the ceiling asset</param>

    public LSType(Guid id,
        MediumName name)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null.");

    }

    public Guid Id { get; }
    public MediumName Name { get; }
}