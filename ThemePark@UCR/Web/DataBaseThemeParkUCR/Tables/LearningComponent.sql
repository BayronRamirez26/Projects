CREATE TABLE ThemePark.LearningComponent (
    LearningComponentAssetId UNIQUEIDENTIFIER NOT NULL,
    LearningComponentType VARCHAR(127) NOT NULL,


    SizeX FLOAT NULL,
    SizeY FLOAT NULL,

    PositionX FLOAT NULL,
    PositionY FLOAT NULL,
    PositionZ FLOAT NULL,

    PRIMARY KEY (LearningComponentAssetId),
);