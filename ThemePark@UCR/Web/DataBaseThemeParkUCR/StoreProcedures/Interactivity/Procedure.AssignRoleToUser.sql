CREATE PROCEDURE [AssignRoleToUser]
    @UserId UNIQUEIDENTIFIER,
    @RoleId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM ThemePark.UsersHaveRoles WHERE UserId = @UserId AND RoleId = @RoleId)
    BEGIN
        UPDATE ThemePark.UsersHaveRoles
        SET IsActive = 1
        WHERE UserId = @UserId AND RoleId = @RoleId;
    END
    ELSE
    BEGIN
        INSERT INTO ThemePark.UsersHaveRoles (UserId, RoleId, IsActive)
        VALUES (@UserId, @RoleId, 1);
    END
END

