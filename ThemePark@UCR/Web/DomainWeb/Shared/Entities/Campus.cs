using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.Entities;

public class Campus
{
    public LongName UniversityName { get; }

    public LongName CampusName { get; }

    public Campus(
        LongName universityName,
        LongName campusName)
    {
        UniversityName = universityName;
        CampusName = campusName;
    }


}
