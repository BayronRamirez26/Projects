CREATE PROCEDURE [DeleteLevel]
	@LevelId UNIQUEIDENTIFIER
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		-- Set the learning spaces foreign key to null
		UPDATE [ThemePark].[LearningSpace]
		SET [LevelId] = NULL
		WHERE [LevelId] = @LevelId

		-- Get the building id
		DECLARE @BuildingId UNIQUEIDENTIFIER
        SELECT @BuildingId = [BuildingId]
        FROM [ThemePark].[Level]
		WHERE [LevelId] = @LevelId

		-- Update the level count in the building
		UPDATE [ThemePark].[Building]
		SET [LevelCount] = [LevelCount] - 1
		WHERE [BuildingId] = @BuildingId

		-- Get the updated level count from the building
		DECLARE @LevelCount TINYINT
		SELECT @LevelCount = [LevelCount]
		FROM [ThemePark].[Building]
		WHERE [BuildingId] = @BuildingId

		-- Update the height of the building
		UPDATE [ThemePark].[Building]
		SET [Height] = @LevelCount * 3
		WHERE [BuildingId] = @BuildingId

		-- Get the level number
		DECLARE @LevelNumber TINYINT
		SELECT @LevelNumber = [LevelNumber]
		FROM [ThemePark].[Level]
		WHERE [LevelId] = @LevelId

		-- Update the level numbers of the levels above the deleted level
		UPDATE [ThemePark].[Level]
        SET [LevelNumber] = [LevelNumber] - 1
        WHERE [BuildingId] = @BuildingId
            AND [LevelNumber] > @LevelNumber
			AND [LevelId] != @LevelId

		-- Delete the level
		DELETE FROM [ThemePark].[Level]
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