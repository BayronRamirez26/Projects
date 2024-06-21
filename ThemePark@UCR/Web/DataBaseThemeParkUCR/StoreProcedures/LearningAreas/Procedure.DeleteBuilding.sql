CREATE PROCEDURE [DeleteBuilding]
	@BuildingId UNIQUEIDENTIFIER
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

		-- Delete the levels with the stored procedure DeleteLevel
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
				EXEC [DeleteLevel] @LevelId
				FETCH NEXT FROM @LevelCursor 
				INTO @LevelId
			END
		CLOSE @LevelCursor
		DEALLOCATE @LevelCursor
		
		-- Delete the building
		DELETE FROM [ThemePark].[Building]
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
