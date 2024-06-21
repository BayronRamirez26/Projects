using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.Repositories;

internal class SqlRoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SqlRoleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Role>> GetAllRolesAsync()
    {
        return await _dbContext.Roles
            .Include(p => p.Permissions)
            .ToListAsync();
    }

    //I should assign the permissions here 
    public async Task<bool> CreateRole(Role roleObject)
    {
        if (roleObject.RoleId == null)
        {
            throw new ArgumentNullException(nameof(roleObject));
        }

        // Permission Logic modified to add Permissions through another method 
        //if (permissionIds == null || !permissionIds.Any())
        //{
        //    throw new ArgumentNullException(nameof(permissionIds));
        //}

        // Fetch existing permissions from the database
        //var existingPermissions = await _dbContext.Set<Permission>()
        //                                          .Where(p => permissionIds.Contains(p.PermissionId))
        //                                          .ToListAsync();

        //if (existingPermissions.Count != permissionIds.Count)
        //{
        //    throw new InvalidOperationException("Some permissions do not exist.");
        //}

        // Clear existing permissions and add the fetched existing permissions
        //roleObject.Permissions.Clear();
        //foreach (var permission in existingPermissions)
        //{
        //    roleObject.Permissions.Add(permission);
        //}

        // Add the role to the context
        await _dbContext.Set<Role>().AddAsync(roleObject);
        await _dbContext.SaveChangesAsync();

        return true;
    }


    
    public async Task<bool> AssignRoleToUser(Guid userId, Guid roleId)
    {
        var userIdParameter = new SqlParameter("@UserId", userId);
        var roleIdParameter = new SqlParameter("@RoleId", roleId);

        var rowsAffected = await _dbContext.Database.ExecuteSqlRawAsync(
            "EXEC [AssignRoleToUser] @UserId, @RoleId",
            userIdParameter,
            roleIdParameter);

        return rowsAffected > 0;
    }

    public async Task<bool> RequestRoleToAdmin(Guid userId, Guid roleId)
    {
        var query = @"
                IF EXISTS (SELECT 1 FROM ThemePark.UsersHaveRoles WHERE UserId = @UserId AND RoleId = @RoleId)
                BEGIN
                    UPDATE ThemePark.UsersHaveRoles
                    SET IsActive = 0
                    WHERE UserId = @UserId AND RoleId = @RoleId
                END
                ELSE
                BEGIN
                    INSERT INTO ThemePark.UsersHaveRoles (UserId, RoleId, IsActive)
                    VALUES (@UserId, @RoleId, 0)
                END";

        var parameters = new[]
        {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@RoleId", roleId)
            };

        await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);
        return true;
    }

    public async Task<bool> AcceptRoleToUser(Guid userId, Guid roleId)
    {
        var query = @"
                UPDATE ThemePark.UsersHaveRoles
                SET IsActive = 1
                WHERE UserId = @UserId AND RoleId = @RoleId";

        var parameters = new[]
        {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@RoleId", roleId)
            };

        var rowsAffected = await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);
        return rowsAffected > 0;
    }


    //Change this so it does not burn sql querys
    public async Task<bool> DeleteRole(Guid roleId)
    {

        var query = "DELETE FROM ThemePark.[Role] WHERE RoleId = @RoleId";

        var parameter = new SqlParameter("@RoleId", roleId);

        var rowsAffected = await _dbContext.Database.ExecuteSqlRawAsync(query, parameter);
        return rowsAffected > 0;
    }

    public async Task<bool> UnassignRoleToUser(Guid userId, Guid roleId)
    {
        var query = @"
                IF EXISTS (SELECT 1 FROM ThemePark.UsersHaveRoles WHERE UserId = @UserId AND RoleId = @RoleId)
                BEGIN
                    DELETE FROM ThemePark.UsersHaveRoles
                    WHERE UserId = @UserId AND RoleId = @RoleId
                END";

        var parameters = new[]
        {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@RoleId", roleId)
            };

        await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);
        return true;
    }
}



