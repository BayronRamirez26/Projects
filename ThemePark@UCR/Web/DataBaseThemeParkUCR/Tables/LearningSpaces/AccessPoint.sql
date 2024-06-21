CREATE TABLE [ThemePark].[Accesspoint] (
    [AccessPointId]   UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [LearningSpaceId] UNIQUEIDENTIFIER,
    [LevelId] UNIQUEIDENTIFIER,
    [CoordX] FLOAT (53),
    [CoordY] FLOAT (53),
    [CoordZ] FLOAT (53),
    [RotationX] FLOAT NULL,
    [RotationY] FLOAT NULL,
    FOREIGN KEY ([LearningSpaceId])
		REFERENCES [ThemePark].[LearningSpace]([LearningSpaceId])
        ON DELETE CASCADE,
    FOREIGN KEY ([LevelId])
		REFERENCES [ThemePark].[Level](LevelId)
        ON DELETE CASCADE
);