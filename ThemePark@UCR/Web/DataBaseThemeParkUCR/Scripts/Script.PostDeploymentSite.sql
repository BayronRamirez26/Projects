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

MERGE INTO ThemePark.Site AS Target
USING (VALUES
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 0, 0),
	('Universidad de Costa Rica', 'Sede Occidente', 'Finca 1', 0, 0),
	('Universidad de Costa Rica', 'Sede recinto Tacares', 'Finca 1', 0, 0)
)
AS SOURCE ([UniversityName], [CampusNameBuffer],[SiteNameBuffer], [SiteSizeXBuffer], [SiteSizeYBuffer])
ON TARGET.[UniversityName] = SOURCE.[UniversityName]
AND [CampusName] = SOURCE.[CampusNameBuffer]
AND [SiteName] = SOURCE.[SiteNameBuffer]
AND [SiteSizeX] = SOURCE.[SiteSizeXBuffer]
AND [SiteSizeY] = SOURCE.[SiteSizeYBuffer]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UniversityName], [CampusName], SiteName, SiteSizeX, SiteSizeY)

		VALUES (SOURCE.[UniversityName], SOURCE.[CampusNameBuffer], SOURCE.[SiteNameBuffer], SOURCE.[SiteSizeXBuffer], SOURCE.[SiteSizeYBuffer])
WHEN MATCHED THEN
	UPDATE SET
		[UniversityName] = SOURCE.[UniversityName],
		[CampusName] = SOURCE.[CampusNameBuffer],
		[SiteName] = SOURCE.[SiteNameBuffer],
		[SiteSizeX] = SOURCE.[SiteSizeXBuffer],
		[SiteSizeY] = SOURCE.[SiteSizeYBuffer];
