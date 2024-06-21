CREATE PROCEDURE [DeleteInteractiveScreen]
    @LearningComponentAssetId INT
AS
BEGIN
    BEGIN TRANSACTION
    IF NOT EXISTS (SELECT 1 FROM ThemePark.InteractiveScreen WHERE LearningComponentAssetId = @LearningComponentAssetId)
    BEGIN
        ROLLBACK TRANSACTION;
        --Throw number must be >50000  && < max_int
        THROW 50000, 'The LearningComponent ID does not exist', 1;
    END;
    BEGIN TRY
        DELETE FROM ThemePark.InteractiveScreen
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