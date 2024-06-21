CREATE PROCEDURE [DeactivateStudent]
    @StudentId UNIQUEIDENTIFIER,
    @IsActive BIT
AS
BEGIN
    UPDATE ThemePark.Student
    SET IsActive = @IsActive
    WHERE StudentId = @StudentId;
END
