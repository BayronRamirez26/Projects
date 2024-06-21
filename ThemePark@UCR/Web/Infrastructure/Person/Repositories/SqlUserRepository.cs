using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.Repositories;
//NOTE: change to public if not working.
//[Authorize]
//[ApiController]
//[Route("[controller]")]
////[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class SqlUserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public SqlUserRepository(ApplicationDbContext dBContext)
    {
        _dbContext = dBContext;
    }

    public async Task<IEnumerable<User>> GetUserCredentialsAsync()
    {
        // SELECT * FROM Users        
        return await _dbContext.Users
            .Include(u => u.Roles)
            .ThenInclude(r => r.Permissions)
            .ToListAsync();

    }


    public async Task<bool> CreateUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        try
        {
            Console.WriteLine(user.UserNickName.Value);
            await _dbContext.Set<User>()
                .AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
        return true;
    }
}

