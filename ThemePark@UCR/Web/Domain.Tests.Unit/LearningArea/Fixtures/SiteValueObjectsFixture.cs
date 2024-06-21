using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningArea.Fixtures;

public class SiteValueObjectsFixture
{
    private const string kUniversityNameValue = "University of Costa Rica";
    private const string kCampusNameValue = "Sede Rodrigo Facio";
    private const string kSiteNameValue = "Finca 1";
    private const double kSizeXValue = 700.0;
    private const double kSizeYValue = 500.0;

    public enum Context
    {
        WithValidParameters,
        WithInvalidUniversityName,
        WithInvalidCampusName,
        WithInvalidSiteName,
        WithInvalidSizeX,
        WithInvalidSizeY
    }

    public LongName UniversityName { get; private set; }
    public LongName CampusName { get; private set; }
    public MediumName SiteName { get; private set; }
    public Size SizeX { get; private set; }
    public Size SizeY { get; private set; }

    public SiteValueObjectsFixture()
    {
        UniversityName = LongName.Create(kUniversityNameValue);
        CampusName = LongName.Create(kCampusNameValue);
        SiteName = MediumName.Create(kSiteNameValue);
        SizeX = Size.Create(kSizeXValue);
        SizeY = Size.Create(kSizeYValue);
    }

    public void ChangeContext(Context context)
    {
        switch (context)
        {
            case Context.WithValidParameters:
                UniversityName = LongName.Create(kUniversityNameValue);
                CampusName = LongName.Create(kCampusNameValue);
                SiteName = MediumName.Create(kSiteNameValue);
                SizeX = Size.Create(kSizeXValue);
                SizeY = Size.Create(kSizeYValue);
                break;
            case Context.WithInvalidUniversityName:
                UniversityName = LongName.Create(string.Empty);
                CampusName = LongName.Create(kCampusNameValue);
                SiteName = MediumName.Create(kSiteNameValue);
                SizeX = Size.Create(kSizeXValue);
                SizeY = Size.Create(kSizeYValue);
                break;
            case Context.WithInvalidCampusName:
                UniversityName = LongName.Create(kUniversityNameValue);
                CampusName = LongName.Create(string.Empty);
                SiteName = MediumName.Create(kSiteNameValue);
                SizeX = Size.Create(kSizeXValue);
                SizeY = Size.Create(kSizeYValue);
                break;
            case Context.WithInvalidSiteName:
                UniversityName = LongName.Create(kUniversityNameValue);
                CampusName = LongName.Create(kCampusNameValue);
                SiteName = MediumName.Create(string.Empty);
                SizeX = Size.Create(kSizeXValue);
                SizeY = Size.Create(kSizeYValue);
                break;
            case Context.WithInvalidSizeX:
                UniversityName = LongName.Create(kUniversityNameValue);
                CampusName = LongName.Create(kCampusNameValue);
                SiteName = MediumName.Create(kSiteNameValue);
                SizeX = Size.Create(-1.0);
                SizeY = Size.Create(kSizeYValue);
                break;
            case Context.WithInvalidSizeY:
                UniversityName = LongName.Create(kUniversityNameValue);
                CampusName = LongName.Create(kCampusNameValue);
                SiteName = MediumName.Create(kSiteNameValue);
                SizeX = Size.Create(kSizeXValue);
                SizeY = Size.Create(-1.0);
                break;
            default:
                break;
        }
    }
}
