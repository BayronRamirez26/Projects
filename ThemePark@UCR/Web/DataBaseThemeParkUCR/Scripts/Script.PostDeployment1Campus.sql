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
MERGE INTO ThemePark.Campus AS Target
USING (VALUES
	('Universidad de Costa Rica', 'Sede Rodrigo Facio'),
	('Universidad de Costa Rica', 'Sede Occidente'),
	('Universidad de Costa Rica', 'Sede recinto Tacares')
)
AS SOURCE ([UniversityName], [CampusNameBuffer])
ON TARGET.[UniversityName] = SOURCE.[UniversityName]
AND [CampusName] = SOURCE.[CampusNameBuffer]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UniversityName], [CampusName])

		VALUES (SOURCE.[UniversityName], SOURCE.[CampusNameBuffer])
WHEN MATCHED THEN
	UPDATE SET
		[UniversityName] = SOURCE.[UniversityName],
		[CampusName] = SOURCE.[CampusNameBuffer];
