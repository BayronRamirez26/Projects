using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.EntityConfigurations;

internal class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Student", schema: "ThemePark");

        builder.HasKey(s => s.StudentId);

        builder.Property(s => s.StudentId)
            .HasConversion(
                convertToProviderExpression: guid => guid.ToString(),
                convertFromProviderExpression: idString => Guid.Parse(idString));

        builder.Property(s => s.PersonId)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: guid => guid.ToString(),
                convertFromProviderExpression: idString => Guid.Parse(idString));

        builder.Property(s => s.StudentCard)
            .IsRequired()
            .HasMaxLength(20)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: cardString => StudentCardValueObject.Create(cardString));

        builder.Property(s => s.IsActive)
            .IsRequired();

        builder
                .InsertUsingStoredProcedure(
                    "[ThemePark].[AssignPersonToStudent]",
                    storedProcedureBuilder =>
                    {
                        storedProcedureBuilder.HasParameter(s => s.PersonId);
                        storedProcedureBuilder.HasParameter(s => s.StudentCard);
                        storedProcedureBuilder.HasParameter(s => s.IsActive);
                        storedProcedureBuilder.HasResultColumn(s => s.StudentId);
                    });

        //builder.HasOne(s => s.Person)
        //    .WithOne(p => p.Student)
        //    .HasForeignKey<Student>(s => s.PersonId)
        //    .OnDelete(DeleteBehavior.Cascade);
    }
}
