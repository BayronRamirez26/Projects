CREATE TABLE [ThemePark].[LearningSpace] (
    [LearningSpaceId]   UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [LevelId]           UNIQUEIDENTIFIER NULL,
    [LearningSpaceName] VARCHAR (127)     NULL,
    [SizeX]             FLOAT (53)       NOT NULL,
    [SizeY]             FLOAT (53)       NOT NULL,
    [SizeZ]             FLOAT (53)       NOT NULL,
    [FloorColor]        VARCHAR (127)    NULL,
    [CeilingColor]      VARCHAR (127)    NULL,
    [WallsColor]        VARCHAR (127)    NULL,
    [Type]                UNIQUEIDENTIFIER    NULL,
    FOREIGN KEY ([Type])
        REFERENCES ThemePark.[LearningSpaceType]([Id]),
    FOREIGN KEY ([LevelId])
        REFERENCES ThemePark.[Level]([LevelId]) ON DELETE SET NULL
);
