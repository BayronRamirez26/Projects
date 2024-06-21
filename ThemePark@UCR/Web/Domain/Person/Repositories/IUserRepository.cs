namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetUserCredentialsAsync();

    public Task<bool> CreateUserAsync(User user);
}
