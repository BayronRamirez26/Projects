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
MERGE INTO ThemePark.University AS Target
USING (VALUES
	('Universidad de Costa Rica')
)
AS SOURCE ([UniversityName])
ON TARGET.[UniversityName] = SOURCE.[UniversityName]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UniversityName])
		VALUES (SOURCE.[UniversityName])
WHEN MATCHED THEN
	UPDATE SET
		[UniversityName] = SOURCE.[UniversityName];