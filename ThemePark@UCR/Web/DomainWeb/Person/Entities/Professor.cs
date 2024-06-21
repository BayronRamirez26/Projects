using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

/// <summary>
/// This represents the Professor entity in our system.
/// It contains the values related to a student
/// </summary>
/// <remarks>
/// </remarks>
public class Professor
{
    /// <summary>
    /// This is the main constructor for the Professor entity
    /// </summary>
    /// <param name="professorId">Professor's unique ID.</param>
    /// <param name="personId">Professor's FK.</param>
    /// <param name="institutionalEmail">Professor's institutional email.</param>
    /// <param name="isActive">Professor's state.</param>

    public Professor() { }
    public Professor(
                    Guid professorId,
                    Guid personId,
                    InstitutionalEmailValueObject institutionalEmail,
                    bool isActive = true)
    {
        ProfessorId = professorId;
        PersonId = personId;
        InstitutionalEmail = institutionalEmail;
        IsActive = isActive;
    }

    /// <summary>
    /// Professor's unique Id.
    /// </summary>
    public Guid ProfessorId { get; set; }

    /// <summary>
    /// Professor's FK to Person.
    /// </summary>
    ///
    public Guid PersonId { get; set; }

    /// <summary>
    /// Professor's institutional email.
    /// </summary>
    public InstitutionalEmailValueObject InstitutionalEmail { get; set; }

    /// <summary>
    /// Professor's state.
    /// </summary>
    public bool IsActive { get; set; }

    // <summary>
    /// Persons's navigation property.
    /// </summary>
    public Persons Person { get; set; }
}