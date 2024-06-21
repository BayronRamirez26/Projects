CREATE TABLE ThemePark.AIAssistant (
    AssistantId INT NOT NULL,
    LearningComponentName VARCHAR(127),
    -- Required by Unity
    SizeX FLOAT NULL,
    SizeY FLOAT NULL,
    PositionX FLOAT NULL,
    PositionY FLOAT NULL,
    PositionZ FLOAT NULL,
    --
    LearningSpaceId UNIQUEIDENTIFIER NULL,  
    PRIMARY KEY (AssistantId),
    -- Required by Unity (LearningComponent Abstract Class)
    FOREIGN KEY (LearningSpaceId) REFERENCES ThemePark.LearningSpace (LearningSpaceId)
);