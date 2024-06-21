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
MERGE INTO ThemePark.AccessPoint AS Target
USING (VALUES
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1'),
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1'),
	('Universidad de Costa Rica', 'Sede Occidente', 'Finca 1'),
	('Universidad de Costa Rica', 'Sede recinto Tacares', 'Finca 1')
)
AS SOURCE ([AccessPointId], [LearningSpaceId], [LevelId])
ON TARGET.[AccessPointId] = SOURCE.[AccessPointId]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([AccessPointId], [LearningSpaceId], [LevelId])
		VALUES (SOURCE.[AccessPointId], SOURCE.[LearningSpaceId], SOURCE.[LevelId])
WHEN MATCHED THEN
	UPDATE SET
		[LearningSpaceId] = SOURCE.[LearningSpaceId],
		[LevelId] = SOURCE.[LevelId];