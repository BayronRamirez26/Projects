using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;

/// <summary>
/// This represents the Student entity in our system.
/// It contains the values related to a student
/// </summary>
/// <remarks>
/// A student inherits from the Person entity
/// </remarks>
public class Student
{
    /// <summary>
    /// This is the main constructor for the Student entity
    /// </summary>
    /// <param name="studentId">Person's unique ID.</param>
    /// <param name="personId">Person's unique ID.</param>
    /// <param name="studentCard">Student's card number.</param>
    /// <param name="isActive">Student's card number.</param>
    public Student() { }
    public Student(
        Guid studentId,
        Guid personId,
        StudentCardValueObject studentCard,        
        bool isActive = true)
    {
        StudentId = studentId;
        PersonId = personId;
        StudentCard = studentCard;
        IsActive = isActive;
    }

    /// <summary>
    /// Student's unique Id.
    /// </summary>
    public Guid StudentId { get; set; }

    /// <summary>
    /// Student's FK to Person.
    /// </summary>
    /// 
    public Guid PersonId { get; set; }
  
    /// <summary>
    /// Student's unique card number.
    /// </summary>
    public StudentCardValueObject StudentCard { get; set; }

    /// <summary>
    /// Student's state.
    /// </summary>
    public bool IsActive { get; set; }

    // <summary>
    /// Persons's navigation property.
    /// </summary>
    public Persons Person { get; set; }
}