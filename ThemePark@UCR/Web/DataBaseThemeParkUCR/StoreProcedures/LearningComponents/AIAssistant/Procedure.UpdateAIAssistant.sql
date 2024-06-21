CREATE PROCEDURE [UpdateAIAssistant]
    @LearningComponentAssetId INT,
    @LearningComponentName VARCHAR(127),
    @SizeX FLOAT,
    @SizeY FLOAT,
    @PositionX FLOAT,
    @PositionY FLOAT,
    @PositionZ FLOAT,
    @RotationX FLOAT,
    @RotationY FLOAT,
    @LearningSpaceId UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRANSACTION
    
    IF NOT EXISTS (SELECT 1 FROM ThemePark.IAAssistant WHERE LearningComponentAssetId = @LearningComponentAssetId)
    BEGIN
        ROLLBACK TRANSACTION;
        --Throw number must be >50000  && < max_int
        THROW 50000, 'The LearningComponent ID does not exist', 1;
    END;
    IF NOT EXISTS (SELECT 1 FROM ThemePark.LearningSpace WHERE LearningSpaceId = @LearningSpaceId)
    BEGIN
        ROLLBACK TRANSACTION;
        --Throw number must be >50000  && < max_int
        THROW 50000, 'The learningSpace ID does not exist', 1;
    END;

    BEGIN TRY
        UPDATE ThemePark.IAAssistant
        SET
            LearningComponentName = @LearningComponentName,
            SizeX = @SizeX,
            SizeY = @SizeY,
            PositionX = @PositionX,
            PositionY = @PositionY,
            PositionZ = @PositionZ,
            RotationX = @RotationX,
            RotationY = @RotationY,
            LearningSpaceId = @LearningSpaceId
        WHERE LearningComponentAssetId = @LearningComponentAssetId;

        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION
        END
    END CATCH
END;
GO