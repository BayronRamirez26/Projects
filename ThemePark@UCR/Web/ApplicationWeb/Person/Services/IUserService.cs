using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;

public interface IUserService
{
    public Task<IEnumerable<User>> GetUserCredentialsAsync();

    public Task<bool> CreateUserAsync(User userEntitie);


    public Task<String> GenerateUserToken(User userEntitie);
}