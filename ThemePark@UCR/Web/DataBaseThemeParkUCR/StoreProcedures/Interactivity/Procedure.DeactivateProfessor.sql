CREATE PROCEDURE DeactivateProfessor
    @ProfessorId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ThemePark.Professor
    SET IsActive = 0
    WHERE ProfessorId = @ProfessorId;
END
