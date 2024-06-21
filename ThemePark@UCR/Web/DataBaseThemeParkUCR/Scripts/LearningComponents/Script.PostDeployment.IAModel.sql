
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
	
