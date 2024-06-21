using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.Repositories;

internal class SqlProfessorRepository : IProfessorRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SqlProfessorRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Professor>> GetProfessorsAsync()
    {
        return await _dbContext.Professors
            .Include(p => p.Person)
            .ThenInclude(person => person.User)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Professor> GetProfessorByIdAsync(Guid professorId)
    {
        var professor = await _dbContext.Professors
        .Include(p => p.Person)
        .ThenInclude(person => person.User)
        .AsNoTracking()
        .FirstOrDefaultAsync(p => p.ProfessorId == professorId);

        if (professor == null)
        {
            throw new InvalidOperationException($"Professor with ID {professorId} not found.");
        }

        return professor;
    }

    public async Task<bool> DeactivateProfessorAsync(Guid professorId)
    {
        var professorIdParameter = new SqlParameter("@ProfessorId", professorId);

        var result = await _dbContext.Database.ExecuteSqlRawAsync(
            "EXEC [DeactivateProfessor] @ProfessorId",
            professorIdParameter);

        return result > 0;
    }

    public async Task<bool> AssignPersonToProfessorAsync(Guid personId, Professor professor)
    {
        var person = await _dbContext.Persons.FindAsync(personId);
        if (person == null)
        {
            throw new ArgumentException("Person does not exist.");
        }

        var professorIdParameter = new SqlParameter
        {
            ParameterName = "@ProfessorId",
            SqlDbType = SqlDbType.UniqueIdentifier,
            Direction = ParameterDirection.Output
        };

        var result = await _dbContext.Database.ExecuteSqlRawAsync(
            "EXEC [AssignPersonToProfessor] @PersonId, @InstitutionalEmail, @IsActive, @ProfessorId OUT",
            new SqlParameter("@PersonId", personId),
            new SqlParameter("@InstitutionalEmail", professor.InstitutionalEmail.Value),
            new SqlParameter("@IsActive", professor.IsActive),
            professorIdParameter);

        professor.ProfessorId = (Guid)professorIdParameter.Value;

        // Verificar que la asignación fue exitosa
        return professor.ProfessorId != Guid.Empty;
    }
}
