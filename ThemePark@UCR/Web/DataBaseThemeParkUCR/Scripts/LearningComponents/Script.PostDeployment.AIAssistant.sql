/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


MERGE INTO ThemePark.AIAssistant AS Target
USING (VALUES
    (1, 'Búsqueda de información'),
	(2, 'Búsqueda de información'),
	(3, 'Generador de imagenes'),
	(4, 'Búsqueda de información'),
	(5, 'Búsqueda de información'),
	(6, 'Generador de imagenes')
	

) AS SOURCE (
	[AssistantId],
	[LearningComponentName])

ON TARGET.[AssistantId] = SOURCE.[AssistantId]
WHEN NOT MATCHED BY TARGET THEN
	INSERT (
		[AssistantId],
		[LearningComponentName])
	VALUES (	
		SOURCE.[AssistantId],
		SOURCE.[LearningComponentName])
	
WHEN MATCHED THEN
	UPDATE SET
	    [LearningComponentName] = SOURCE.[LearningComponentName];
