
using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.Repositories;

internal class SqlPersonsRepository : IPersonRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SqlPersonsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> CreatePersonAsync(Persons person)
    {
        if (person == null)
        {
            throw new ArgumentNullException(nameof(person));
        }

        await _dbContext.Set<Persons>()
                .AddAsync(person);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeletePersonAsync(Guid personId)
    {
        var personToDelete = await _dbContext.Persons.FindAsync(personId);
        if (personToDelete != null)
        {
            _dbContext.Persons.Remove(personToDelete);
            await _dbContext.SaveChangesAsync();
        }

        return true;
    }

    public async Task<IEnumerable<Persons>> GetPersonAsync()
    {
        return await _dbContext.Persons
        .Include(p => p.User)
        .ThenInclude(u => u.Roles)
        .ThenInclude(r => r.Permissions)
        .ToListAsync();
    }

    public async Task<Persons?> GetPersonByIdAsync(Guid personId)
    {
        return await _dbContext.Persons.AsNoTracking().FirstOrDefaultAsync(p => p.PersonId == personId);
    }

    public async Task<bool> UpdatePersonAsync(Persons person)
    {
        _dbContext.Entry(person).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return true;
    }
}