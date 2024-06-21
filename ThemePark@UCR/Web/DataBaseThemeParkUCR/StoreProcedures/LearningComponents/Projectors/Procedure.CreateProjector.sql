CREATE PROCEDURE [CreateProjector]
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
    
    --Learning Space verification

    IF NOT EXISTS (SELECT 1 FROM ThemePark.LearningSpace WHERE LearningSpaceId = @LearningSpaceId)
    BEGIN
        ROLLBACK TRANSACTION;
        --Throw number must be >50000  && < max_int
        THROW 50000, 'The learningSpace ID does not exist', 1;
    END;

    BEGIN TRY
        INSERT INTO ThemePark.Projector(
            LearningComponentName,
            SizeX,
            SizeY,
            PositionX,
            PositionY,
            PositionZ,
            RotationX,
            RotationY,
            LearningSpaceId
        )
        VALUES (
            @LearningComponentName,
            @SizeX,
            @SizeY,
            @PositionX,
            @PositionY,
            @PositionZ,
            @RotationX,
            @RotationY,
            @LearningSpaceId
        );
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