namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;

/// <summary>
/// Wrapper that allows to change Guid in Kiota generation
/// </summary>
public class GuidWrapper
{
    /// <summary>
    /// Guid value
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Declare invalid input for GuidWrapper
    /// </summary>

    public static GuidWrapper Create(Guid guid)
    {
        return new GuidWrapper(guid);
    }


    /// <summary>
    /// Primary constructor, input Guid should be not empty
    /// </summary>
    /// <param name="value">Guid input neccesary to create</param>
    public GuidWrapper(Guid value)
    {
        Value = value;
    }
}
