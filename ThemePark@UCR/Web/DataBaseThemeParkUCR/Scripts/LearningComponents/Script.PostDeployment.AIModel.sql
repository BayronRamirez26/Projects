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

MERGE INTO ThemePark.AIModel AS Target
USING (VALUES
    ('GPT4', 'Modelo de lenguaje'),

    ('GPT-3.5', 'Modelo de lenguaje'),
    
    ('DALL-E', 'Modelo de generacion de imágenes')

) AS SOURCE (
	[ModelName],
	[ModelType]
	)

ON TARGET.ModelName  = SOURCE.ModelName 
WHEN NOT MATCHED BY TARGET THEN
	INSERT (
		[ModelName],
		[ModelType]
		)
	VALUES (
		SOURCE.[ModelName],
		SOURCE.[ModelType]
	)
WHEN MATCHED THEN
	UPDATE SET
		[ModelType] = SOURCE.[ModelType];
	
