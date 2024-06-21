CREATE PROCEDURE [AddLevel]
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
        SET @LearningSpaceCount = 0

        -- Get the building id
        SELECT @BuildingId = [BuildingId]
        FROM [ThemePark].[Building]
	    WHERE [UniversityName] = @UniversityName
		    AND [CampusName] = @CampusName
		    AND [SiteName] = @SiteName
		    AND [BuildingAcronym] = @BuildingAcronym

        -- Add the level
        INSERT INTO [ThemePark].[Level] (
            [LevelId], 
            [BuildingId], 
            [UniversityName], 
            [CampusName], 
            [SiteName], 
            [BuildingAcronym], 
            [LevelNumber], 
            [SizeX], 
            [SizeY],
            [SizeZ], 
            [WallsColor], 
            [FloorColor], 
            [CeilingColor], 
            [LearningSpaceCount]
        )
        VALUES (
		    @LevelId, 
		    @BuildingId, 
		    @UniversityName, 
		    @CampusName, 
		    @SiteName, 
		    @BuildingAcronym, 
		    @LevelNumber, 
		    @SizeX, 
		    @SizeY, 
		    @SizeZ, 
		    @WallsColor, 
		    @FloorColor, 
		    @CeilingColor, 
		    @LearningSpaceCount
	    )

        -- Update the level count in the building
        UPDATE [ThemePark].[Building]
        SET [LevelCount] = [LevelCount] + 1
	    WHERE [BuildingId] = @BuildingId

        -- Get the level count from the building
        DECLARE @LevelCount TINYINT
        SELECT @LevelCount = [LevelCount]
        FROM [ThemePark].[Building]
        WHERE [BuildingId] = @BuildingId

        -- Update the height of the building
        DECLARE @Height FLOAT
        SET @Height = @LevelCount * 3
        UPDATE [ThemePark].[Building]
        SET [Height] = @Height
		WHERE [BuildingId] = @BuildingId

        -- Update the level numbers of the levels above the added level
        UPDATE [ThemePark].[Level]
        SET [LevelNumber] = [LevelNumber] + 1
        WHERE [BuildingId] = @BuildingId
            AND [LevelNumber] >= @LevelNumber
			AND [LevelId] != @LevelId

        COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION
		END
	END CATCH
END
