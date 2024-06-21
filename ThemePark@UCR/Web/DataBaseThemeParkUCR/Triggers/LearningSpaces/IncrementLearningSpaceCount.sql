CREATE TRIGGER trg_IncrementLearningSpaceCount
ON ThemePark.LearningSpace
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Update the LearningSpaceCount in the Level table
    UPDATE ThemePark.[Level]
    SET LearningSpaceCount = ISNULL(LearningSpaceCount, 0) + 1
    FROM ThemePark.[Level] L
    JOIN inserted I ON L.LevelId = I.LevelId
END;
GO
