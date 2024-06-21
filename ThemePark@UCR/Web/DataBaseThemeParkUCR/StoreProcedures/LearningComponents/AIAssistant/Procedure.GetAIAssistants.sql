CREATE PROCEDURE [GetAIAssistants]
AS
BEGIN
    SELECT * FROM ThemePark.IAAssistant;
END;
GO