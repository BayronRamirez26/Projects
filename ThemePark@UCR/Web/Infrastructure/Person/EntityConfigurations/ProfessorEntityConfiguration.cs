using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.EntityConfigurations;

internal class ProfessorEntityConfiguration : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.ToTable("Professor", schema: "ThemePark");

        builder.HasKey(p => p.ProfessorId);

        builder.Property(p => p.ProfessorId)
            .HasConversion(
                convertToProviderExpression: guid => guid.ToString(),
                convertFromProviderExpression: idString => Guid.Parse(idString))
            .IsRequired()
            .ValueGeneratedOnAdd(); ;

        builder.Property(p => p.PersonId)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: guid => guid.ToString(),
                convertFromProviderExpression: idString => Guid.Parse(idString));

        builder.Property(p => p.InstitutionalEmail)
            .IsRequired()
            .HasMaxLength(320)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: emailString => InstitutionalEmailValueObject.Create(emailString));

        builder.Property(p => p.IsActive)
            .IsRequired();

        //builder.HasOne(p => p.Person)
        //    .WithOne(p => p.Professor)
        //    .HasForeignKey<Professor>(p => p.PersonId)
        //    .OnDelete(DeleteBehavior.Cascade);

        builder
               .InsertUsingStoredProcedure(
                   "AssignPersonToProfessor",
                   storedProcedureBuilder =>
                   {
                       storedProcedureBuilder.HasParameter(p => p.PersonId);
                       storedProcedureBuilder.HasParameter(p => p.InstitutionalEmail);
                       storedProcedureBuilder.HasParameter(p => p.IsActive);
                       storedProcedureBuilder.HasResultColumn(p => p.ProfessorId);
                   });
    }
}
