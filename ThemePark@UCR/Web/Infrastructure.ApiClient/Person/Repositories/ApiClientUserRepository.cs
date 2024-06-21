using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Repositories;

public class ApiClientUserRepository : IUserRepository
{
    private readonly ApiClientKiota _apiClient;

    public ApiClientUserRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IEnumerable<DomainWeb.Person.Entities.User>> GetUserCredentialsAsync()
    {
        var response = await _apiClient.ShowActiveUsers.GetAsync(); //Para poder hacer await de un task, el método debe estar como async
        var activeUserEntities = response?.ActiveUsers?.Select(UserDtoMapper.ToEntity)
            ?? throw new NullReferenceException();
        return activeUserEntities;
        //return null;
    }

    public async Task<bool> CreateUserAsync(DomainWeb.Person.Entities.User userDomain)
    {
        try
        {
            var createUser = KiotaUserDtoMapper.ToCreateUserRequest(userDomain);

            try
            {
                var output = await _apiClient.CreateUser.PostAsync(createUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with RequestBuilder {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    public async Task<String> GenerateUserToken(DomainWeb.Person.Entities.User userEntitie)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key_here_must_be_this_large"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userEntitie.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, userEntitie.UserNickName.Value) // Ensure a name claim is included
        };

        // Use a HashSet to store permissions and ensure no duplicates
        var permissionSet = new HashSet<string>();

        foreach (var role in userEntitie.Roles)
        {
            foreach (var permission in role.Permissions)
            {
                Console.WriteLine(permission.PermissionDescription.Value);
                permissionSet.Add(permission.PermissionDescription.Value);
            }
        }

        // Add unique permissions to the claims
        foreach (var permission in permissionSet)
        {
            claims.Add(new Claim("permission", permission));
        }


        var token = new JwtSecurityToken(
            issuer: "your_issuer",
            audience: "your_audience",
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
