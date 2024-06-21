public class LayoutStateService
{
    public event Action OnChange;

    public void NotifyStateChanged() => OnChange?.Invoke();
}


public class RolesStateService
{
    public event Action OnChange;

    public void NotifyStateChanged() => OnChange?.Invoke();
}
