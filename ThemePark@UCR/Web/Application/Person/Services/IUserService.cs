using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Person.Services;

public interface IUserService
{
    public Task<IEnumerable<User>> GetUserCredentialsAsync();

    public Task<bool> CreateUserAsync(User userEntitie);
}