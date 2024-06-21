CREATE PROCEDURE [AssignPersonToProfessor]
    @PersonId UNIQUEIDENTIFIER,
    @InstitutionalEmail VARCHAR(320),
    @IsActive BIT,
    @ProfessorId UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Generar el nuevo ID de profesor
    SET @ProfessorId = NEWID();

    -- Hace un insert del nuevo registro en la tabla Professor
    INSERT INTO ThemePark.Professor (ProfessorId, PersonId, InstitutionalEmail, IsActive)
    VALUES (@ProfessorId, @PersonId, @InstitutionalEmail,  @IsActive);

    SELECT @ProfessorId AS ProfessorId;
END
