CREATE TABLE ThemePark.AIModel (
    ModelID INT IDENTITY (1,1) NOT NULL,
    ModelName VARCHAR(127),
    ModelType VARCHAR(127),
    PRIMARY KEY (ModelID)
)