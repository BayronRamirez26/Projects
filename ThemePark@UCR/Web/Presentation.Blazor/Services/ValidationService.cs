namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services
{
    public class ValidationService
    {
        public ValidationService() { }
        public async Task<bool> hasPermition(CurrentNavigationUser currentNavigationUser, string action)
        {
            await currentNavigationUser.LoadUserAsync();
            if (currentNavigationUser.CurrentUser != null)
            {
                foreach (var role in currentNavigationUser.CurrentUser.Roles)
                {
                    foreach (var permission in role.Permissions)
                    {
                        Console.WriteLine(permission.PermissionDescription.Value);
                        if (permission.PermissionDescription.Value == action)
                        {
                            Console.WriteLine("PUEDE CREAR");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("=====================================");
                            Console.WriteLine(permission.PermissionDescription.Value);
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }
    }
}
