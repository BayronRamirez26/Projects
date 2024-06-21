CREATE TABLE ThemePark.Whiteboard (
    LearningComponentAssetId INT IDENTITY (1,1) NOT NULL,
    LearningComponentName VARCHAR(127) NULL,
    SizeX FLOAT NULL,
    SizeY FLOAT NULL,
    PositionX FLOAT NULL,
    PositionY FLOAT NULL,
    PositionZ FLOAT NULL,
    RotationX FLOAT NULL,
    RotationY FLOAT NULL,
    LearningSpaceId UNIQUEIDENTIFIER NULL,
    FOREIGN KEY (LearningSpaceId) REFERENCES ThemePark.LearningSpace ([LearningSpaceId]),
    PRIMARY KEY (LearningComponentAssetId),
)