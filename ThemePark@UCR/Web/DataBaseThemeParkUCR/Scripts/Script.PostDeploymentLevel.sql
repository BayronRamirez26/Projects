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
MERGE INTO ThemePark.Level AS Target
USING (VALUES
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI Anexo', 04, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 03, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede Occidente', 'Finca 1', 'AQ', 02, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede recinto Tacares', 'Finca 1', 'IE', 02, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 01, 0, 0, 0)
)
AS SOURCE ([UniversityNameBuffer], [CampusNameBuffer], [SiteNameBuffer],[BuildingAcronymBuffer], [LevelNumberBuffer], [SizeXBuffer], [SizeYBuffer], [SizeZBuffer])
ON TARGET.[UniversityName] = SOURCE.[UniversityNameBuffer]
AND [CampusName] = SOURCE.[CampusNameBuffer]
AND [SiteName] = SOURCE.[SiteNameBuffer]
AND [BuildingAcronym] = SOURCE.[BuildingAcronymBuffer]
AND [LevelNumber] = SOURCE.[LevelNumberBuffer]
AND [SizeX] = SOURCE.[SizeXBuffer]
AND [SizeY] = SOURCE.[SizeYBuffer]
AND [SizeZ] = SOURCE.[SizeZBuffer]

WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UniversityName], [CampusName], [SiteName],[BuildingAcronym], [LevelNumber], [SizeX], [SizeY], [SizeZ])

		VALUES (SOURCE.[UniversityNameBuffer], SOURCE.[CampusNameBuffer], SOURCE.[SiteNameBuffer], SOURCE.[BuildingAcronymBuffer], SOURCE.[LevelNumberBuffer], SOURCE.[SizeXBuffer], SOURCE.[SizeYBuffer], SOURCE.[SizeZBuffer] )
WHEN MATCHED THEN
	UPDATE SET
		[UniversityName] = SOURCE.[UniversityNameBuffer],
		[CampusName] = SOURCE.[CampusNameBuffer],
		[SiteName] = SOURCE.[SiteNameBuffer],
		[BuildingAcronym] = SOURCE.[BuildingAcronymBuffer],
		[LevelNumber] = SOURCE.[LevelNumberBuffer],
		[SizeX] = SOURCE.[SizeXBuffer],
		[SizeY] = SOURCE.[SizeYBuffer],
		[SizeZ] = SOURCE.[SizeZBuffer];