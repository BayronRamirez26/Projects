CREATE PROCEDURE [UpdateBuilding]
	@BuildingId UNIQUEIDENTIFIER,
	@UniversityName VARCHAR(255),
	@CampusName VARCHAR(255),
	@SiteName VARCHAR(127),
	@BuildingAcronym VARCHAR(10),
	@BuildingName VARCHAR(255),
    @CenterX FLOAT,
    @CenterY FLOAT,
	@Length FLOAT,
    @Width FLOAT,
    @Rotation FLOAT,
	@WallsColor CHAR(7),
    @RoofColor CHAR(7),
	@Height FLOAT,
	@LevelCount TINYINT
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY

		-- Get the levels of the building
		DECLARE @Levels TABLE (
			[LevelId] UNIQUEIDENTIFIER
		)
		INSERT INTO @Levels
		SELECT [LevelId]
		FROM [ThemePark].[Level]
		WHERE [BuildingId] = @BuildingId

		-- Update the levels with the stored procedure UpdateLevel
		DECLARE @LevelId UNIQUEIDENTIFIER
		DECLARE @LevelCursor CURSOR
		SET @LevelCursor = CURSOR FOR
		SELECT [LevelId]
		FROM @Levels
		OPEN @LevelCursor
			FETCH NEXT FROM @LevelCursor 
			INTO @LevelId
			WHILE @@FETCH_STATUS = 0
			BEGIN
				-- Get the level data
				DECLARE @LevelNumber TINYINT
				DECLARE @SizeX FLOAT
				DECLARE @SizeY FLOAT
				DECLARE @SizeZ FLOAT
				DECLARE @LevelWallsColor CHAR(7)
				DECLARE @FloorColor CHAR(7)
				DECLARE @CeilingColor CHAR(7)
				DECLARE @LearningSpaceCount TINYINT
				SELECT @LevelNumber = [LevelNumber],
					   @SizeX = [SizeX],
					   @SizeY = [SizeY],
					   @SizeZ = [SizeZ],
					   @LevelWallsColor = [WallsColor],
					   @FloorColor = [FloorColor],
					   @CeilingColor = [CeilingColor],
					   @LearningSpaceCount = [LearningSpaceCount]
				FROM [ThemePark].[Level]
				WHERE [LevelId] = @LevelId
				EXEC [UpdateLevel] @LevelId, @UniversityName, @CampusName, @SiteName, @BuildingAcronym, @LevelNumber, @SizeX, @SizeY, @SizeZ, @LevelWallsColor, @FloorColor, @CeilingColor, @LearningSpaceCount, @BuildingId
				FETCH NEXT FROM @LevelCursor 
				INTO @LevelId
			END
		CLOSE @LevelCursor
		DEALLOCATE @LevelCursor

		-- Get the level count
		SELECT @LevelCount = [LevelCount]
		FROM [ThemePark].[Building]
		WHERE [BuildingId] = @BuildingId

		-- Set the height
		SET @Height = @LevelCount * 3

		-- Update the building
		UPDATE [ThemePark].[Building]
		SET [UniversityName] = @UniversityName,
			[CampusName] = @CampusName,
			[SiteName] = @SiteName,
			[BuildingAcronym] = @BuildingAcronym,
			[BuildingName] = @BuildingName,
			[CenterX] = @CenterX,
			[CenterY] = @CenterY,
			[Rotation] = @Rotation,
			[Length] = @Length,
			[Width] = @Width,
			[Height] = @Height,
			[WallsColor] = @WallsColor,
			[RoofColor] = @RoofColor,
			[LevelCount] = @LevelCount
		WHERE [BuildingId] = @BuildingId

        COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION
		END
	END CATCH
END
