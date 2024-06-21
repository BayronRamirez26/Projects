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
MERGE INTO ThemePark.Building AS Target
USING (VALUES
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI Anexo', 'Edificio anexo de la ECCI', 0, 0, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 'Edificio viejo de la ECCI', 0, 0, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede Occidente', 'Finca 1', 'AQ', 'Edificio numero 255', 0, 0, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede recinto Tacares', 'Finca 1', 'IE', 'Edificio importante numero 2', 0, 0, 0, 0, 0)
)
AS SOURCE ([UniversityNameBuffer], [CampusNameBuffer], [SiteNameBuffer],[BuildingAcronymBuffer], [BuildingNameBuffer], [CoordinateXBuffer], [CoordinateYBuffer], [SizeXBuffer], [SizeYBuffer], [RotationBuffer]) -- , [LevelCount]
ON TARGET.[UniversityName] = SOURCE.[UniversityNameBuffer]
AND [CampusName] = SOURCE.[CampusNameBuffer]
AND [SiteName] = SOURCE.[SiteNameBuffer]
AND [BuildingAcronym] = SOURCE.[BuildingAcronymBuffer]
AND [BuildingName] = SOURCE.[BuildingNameBuffer]
AND [CoordinateX] = SOURCE. [CoordinateXBuffer]
AND [CoordinateY] = SOURCE.[CoordinateYBuffer]
AND [SizeX] = SOURCE.[SizeXBuffer]
AND [SizeY] = SOURCE.[SizeYBuffer]
AND [Rotation] = SOURCE.[RotationBuffer]

WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UniversityName], [CampusName], [SiteName],[BuildingAcronym], [BuildingName], [CoordinateX], [CoordinateY], [SizeX], [SizeY], [Rotation])

		VALUES (SOURCE.[UniversityNameBuffer], SOURCE.[CampusNameBuffer], SOURCE.[SiteNameBuffer], SOURCE.[BuildingAcronymBuffer], SOURCE.[BuildingNameBuffer], SOURCE.[CoordinateXBuffer], SOURCE.[CoordinateYBuffer], SOURCE.[SizeXBuffer], SOURCE.[SizeYBuffer], SOURCE.[RotationBuffer])

WHEN MATCHED THEN
	UPDATE SET
		[UniversityName] = SOURCE.[UniversityNameBuffer],
		[CampusName] = SOURCE.[CampusNameBuffer],
		[SiteName] = SOURCE.[SiteNameBuffer],
		[BuildingAcronym] = SOURCE.[BuildingAcronymBuffer],
		[BuildingName] = SOURCE.[BuildingNameBuffer],
		[CoordinateX] = SOURCE.[CoordinateXBuffer],
		[CoordinateY] = SOURCE.[CoordinateYBuffer],
		[SizeX] = SOURCE.[SizeXBuffer],
		[SizeY] = SOURCE.[SizeYBuffer],
		[Rotation] = SOURCE.[RotationBuffer];
