namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetUserCredentialsAsync();

    public Task<bool> CreateUserAsync(User user);

    public Task<String> GenerateUserToken(User user);
}
