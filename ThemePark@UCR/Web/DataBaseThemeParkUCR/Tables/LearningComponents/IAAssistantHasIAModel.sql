CREATE TABLE ThemePark.IAAssistantHasIAModel (
    AssistantId INT NOT NULL,
    ModelId INT NOT NULL,
    PRIMARY KEY (AssistantId, ModelId)
);