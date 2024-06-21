CREATE TABLE ThemePark.AIAssistantHasAIModel (
    AssistantId INT NOT NULL,
    ModelId INT NOT NULL,
    PRIMARY KEY (AssistantId, ModelId),
    FOREIGN KEY (AssistantId) REFERENCES ThemePark.AIAssistant(AssistantId),
    FOREIGN KEY (ModelId) REFERENCES ThemePark.AIModel(ModelId)
);