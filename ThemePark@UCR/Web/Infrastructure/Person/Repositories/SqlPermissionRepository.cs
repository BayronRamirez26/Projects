using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.Repositories;

internal class SqlPermissionRepository : IPermissionRepository
{
    private readonly ApplicationDbContext _dbContext;
    public SqlPermissionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
    {
        return await _dbContext.Permissions
            .ToListAsync();
    }

    public async Task<bool> AssignPermissionToRole(Guid roleId, Guid permissionId)
    {
        //var permission = _dbContext.Set<RoleHavePermission>();
        //await permission.AddAsync(new RoleHavePermission { RoleId = roleId, PermissiionId = "PermissionId" });
        Console.WriteLine("Id role que llego:");
        Console.WriteLine(roleId);
        //_dbContext.SaveChanges();
        var query = @"
            INSERT INTO ThemePark.RolesHavePermissions (RoleId, PermissionId)
            VALUES (@RoleId, @PermissionId)";

        var parameters = new[]
        {
                new SqlParameter("@RoleId", roleId),
                new SqlParameter("@PermissionId", permissionId)
            };

        await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);
        return true;
    }

}
