CREATE TABLE ThemePark.AIModel (
    ModelId INT IDENTITY (1,1) NOT NULL,
    ModelName VARCHAR(127),
    ModelType VARCHAR(127),
    PRIMARY KEY (ModelId)
)