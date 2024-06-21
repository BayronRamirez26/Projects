using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;

public class Site
{
    public Site(
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        Size sizeX,
        Size sizeY)
    {
        UniversityName = universityName;
        CampusName = campusName;
        SiteName = siteName;
        SizeX = sizeX;
        SizeY = sizeY;
    }

    public LongName UniversityName { get; }

    public LongName CampusName { get; }

    public MediumName SiteName { get; }

    public Size SizeX { get; }

    public Size SizeY { get; }
}
