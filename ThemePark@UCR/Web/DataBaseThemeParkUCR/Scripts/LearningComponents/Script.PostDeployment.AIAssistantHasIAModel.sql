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
    (1,1),
	(1,2),
	(1,3),
	(2,1),
	(2,3),
	(3,3),
	(4,1),
	(4,2),
	(4,3),
	(5,1),
	(5,3),
	(6,3)

) AS SOURCE (
	[AssistantId],
	[ModelId])

ON TARGET.[AssistantId] = SOURCE.[AssistantId]
WHEN NOT MATCHED BY TARGET THEN
	INSERT (
		[AssistantId],
		[ModelId])
	VALUES (	
		SOURCE.[AssistantId],
		SOURCE.[ModelId])
	
WHEN MATCHED THEN
	UPDATE SET
	    [ModelId] = SOURCE.[ModelId];
