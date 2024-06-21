using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningComponents.Fixtures;
public class LComponentIDFixture
{
    public enum Context
    {
        ValidValue,
        NullValue,
        ValueBelowMin,
        ValueAboveMax
    }

    public LComponentID? ComponentID { get; private set; }

    public void ChangeContext(Context context)
    {
        switch (context)
        {
            case Context.ValidValue:
                ComponentID = LComponentID.Create(5);
                break;
            case Context.NullValue:
                ComponentID = LComponentID.Create(null);
                break;
            case Context.ValueBelowMin:
                ComponentID = LComponentID.Create(-1);
                break;
            /*case Context.ValueAboveMax:
                ComponentID = LComponentID.Create((int)(int.MaxValue + 1L));
                break;*/
            default:
                break;
        }
    }
}

