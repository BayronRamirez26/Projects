CREATE PROCEDURE [UpdateLevel]
	@LevelId UNIQUEIDENTIFIER,
    @UniversityName VARCHAR(255),
    @CampusName VARCHAR(255),
    @SiteName VARCHAR(127),
    @BuildingAcronym VARCHAR(10),
    @LevelNumber TINYINT,
    @SizeX FLOAT,
    @SizeY FLOAT,
    @SizeZ FLOAT,
    @WallsColor CHAR(7),
    @FloorColor CHAR(7),
    @CeilingColor CHAR(7),
    @LearningSpaceCount TINYINT,
    @BuildingId UNIQUEIDENTIFIER
AS
BEGIN    
	BEGIN TRANSACTION

	BEGIN TRY

        -- Update the level
        UPDATE [ThemePark].[Level]
        SET [UniversityName] = @UniversityName,
            [CampusName] = @CampusName,
            [SiteName] = @SiteName,
            [BuildingAcronym] = @BuildingAcronym,
            [SizeX] = @SizeX,
			[SizeY] = @SizeY,
			[SizeZ] = @SizeZ,
			[WallsColor] = @WallsColor,
			[FloorColor] = @FloorColor,
			[CeilingColor] = @CeilingColor
		WHERE [LevelId] = @LevelId

        COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION
		END
	END CATCH
END
