using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.Repositories;

internal class SqlStudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SqlStudentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync()
    {
        return await _dbContext.Students
            .Include(s => s.Person)
            .ThenInclude(person => person.User)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Student> GetStudentByIdAsync(Guid studentId)
    {
        var student = await _dbContext.Students
        .Include(s => s.Person)
        .ThenInclude(person => person.User)
        .AsNoTracking()
        .FirstOrDefaultAsync(s => s.StudentId == studentId);

        if (student == null)
        {
            throw new InvalidOperationException($"Student with ID {studentId} not found.");
        }

        return student;
    }

    public async Task<bool> DeactivateStudentAsync(Guid studentId)
    {
        var studentIdParameter = new SqlParameter("@StudentId", studentId);
        var isActiveParameter = new SqlParameter("@IsActive", false);

        var rowsAffected = await _dbContext.Database.ExecuteSqlRawAsync(
            "EXEC [DeactivateStudent] @StudentId, @IsActive",
            studentIdParameter,
            isActiveParameter);

        return rowsAffected > 0;
    }

    public async Task<bool> AssignPersonToStudentAsync(Guid personId, Student student)
    {
        var person = await _dbContext.Persons.FindAsync(personId);
        if (person == null)
        {
            throw new ArgumentException("Person does not exist.");
        }

        var studentIdParameter = new SqlParameter
        {
            ParameterName = "@StudentId",
            SqlDbType = SqlDbType.UniqueIdentifier,
            Direction = ParameterDirection.Output
        };

        var result = await _dbContext.Database.ExecuteSqlRawAsync(
            "EXEC [AssignPersonToStudent] @PersonId, @StudentCard, @IsActive, @StudentId OUT",
            new SqlParameter("@PersonId", personId),
            new SqlParameter("@StudentCard", student.StudentCard.Value),
            new SqlParameter("@IsActive", student.IsActive),
            studentIdParameter);

        student.StudentId = (Guid)studentIdParameter.Value;

        return result > 0;
    }
    
}
