CREATE PROCEDURE [AssignPersonToStudent]
    @PersonId UNIQUEIDENTIFIER,
    @StudentCard VARCHAR(20),
    @IsActive BIT,
    @StudentId UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Generar el nuevo ID de estudiante
    SET @StudentId = NEWID();

    -- Hace un insert del registro nuevo en la tabla Student
    INSERT INTO ThemePark.Student (StudentId, PersonId, StudentCard, IsActive)
    VALUES (@StudentId, @PersonId, @StudentCard, @IsActive);

    -- Devolver el StudentId generado
    SELECT @StudentId AS StudentId;

    -- Cantidad de filas afectadas
    RETURN @@ROWCOUNT;
END

