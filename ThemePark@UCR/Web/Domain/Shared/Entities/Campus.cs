using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Entities;

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
