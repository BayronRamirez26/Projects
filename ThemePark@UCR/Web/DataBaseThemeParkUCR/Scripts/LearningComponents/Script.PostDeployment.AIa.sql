/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO ThemePark.InteractiveScreen AS Target
USING (VALUES
	('4','Pantalla interactiva 1', 200.0, 2000.0, 0.0, 0.0, 0.0),

    ('5','Pantalla interactiva 2', 200.0, 180.0, 0.0, 0.0, 0.0),
    
    ('6','Pantalla interactiva 3', 200.0, 150.0, 0.0, 0.0, 0.0)

) AS SOURCE (
	[AssistantId],
	[LearningComponentName],
	[SizeX],
	[SizeY],
	[PositionX],
	[PositionY],
	[PositionZ])

ON TARGET.[LearningComponentName] = SOURCE.[LearningComponentName]
WHEN NOT MATCHED BY TARGET THEN
	INSERT (
	[AssistantId],
	[LearningComponentName],
	[SizeX],
	[SizeY],
	[PositionX],
	[PositionY],
	[PositionZ])
	VALUES (
		SOURCE.[AssistantId],
		SOURCE.[LearningComponentName],
		SOURCE.[SizeX],
		SOURCE.[SizeY],
		SOURCE.[PositionX],
		SOURCE.[PositionY],
		SOURCE.[PositionZ])
	
WHEN MATCHED THEN
	UPDATE SET
	    [LearningComponentName] = SOURCE.[LearningComponentName],
		[AssistantId] = SOURCE.[AssistantId],
		[SizeX] = SOURCE.[SizeX],
		[SizeY] =SOURCE.[SizeY],
		[PositionX] = SOURCE.[PositionX],
		[PositionY] = SOURCE.[PositionY],
		[PositionZ]= SOURCE.[PositionZ];
