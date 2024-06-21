using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;

public class CreateRoleRequestDto
{
    public Role RoleObject { get; set; }
    public List<Guid> PermissionIds { get; set; }
}