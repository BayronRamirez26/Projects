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
	('Pantalla interactiva 1', 1, 1, 0, 0, 0.0, 0.0, 0.0, 'd406ab33-140e-4b23-899d-c29acbbb2bc2'),

    ('Pantalla interactiva 2', 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0,  'd406ab33-140e-4b23-899d-c29acbbb2bc2'),
    
    ('Pantalla interactiva 3', 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, '37c0a8b0-6883-4986-bd49-59daf6d18c97')

) AS SOURCE (
	[LearningComponentName],
	[SizeX],
	[SizeY],
	[PositionX],
	[PositionY],
	[PositionZ],
	[RotationX],
	[RotationY],
	[LearningSpaceId])

ON TARGET.[LearningComponentName] = SOURCE.[LearningComponentName]
WHEN NOT MATCHED BY TARGET THEN
	INSERT (
	[LearningComponentName],
	[SizeX],
	[SizeY],
	[PositionX],
	[PositionY],
	[PositionZ],
	[RotationX],
	[RotationY],
	[LearningSpaceId])
	VALUES (
		SOURCE.[LearningComponentName],
		SOURCE.[SizeX],
		SOURCE.[SizeY],
		SOURCE.[PositionX],
		SOURCE.[PositionY],
		SOURCE.[PositionZ],
		SOURCE.[RotationX],
		SOURCE.[RotationY],
		SOURCE.[LearningSpaceId])
	
WHEN MATCHED THEN
	UPDATE SET
		[LearningComponentName]= SOURCE.[LearningComponentName],
		[SizeX] = SOURCE.[SizeX],
		[SizeY] =SOURCE.[SizeY],
		[PositionX] = SOURCE.[PositionX],
		[PositionY] = SOURCE.[PositionY],
		[PositionZ]= SOURCE.[PositionZ],
		[RotationX] = SOURCE.[RotationX],
		[RotationY] = SOURCE.[RotationY],
		[LearningSpaceId]= SOURCE.[LearningSpaceId];