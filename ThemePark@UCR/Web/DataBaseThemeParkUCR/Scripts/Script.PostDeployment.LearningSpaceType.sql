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
MERGE INTO ThemePark.LearningSpaceType AS TARGET
USING (VALUES
    ('1b9a3e7d-0b3d-4947-a0fc-6fc6d0e894ed', 'Clase'),
    ('33eec130-ec17-4b4f-95f8-2b85adc28209', 'Laboratorio'),
    ('239c46cf-5d09-4e71-9071-89b863cd60f4', 'Auditorio')
)
AS SOURCE ([Id], [Name])
ON TARGET.[Id] = SOURCE.[Id]
AND TARGET.[Name] = SOURCE.[Name]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Id], [Name])
    VALUES (SOURCE.[Id], SOURCE.[Name])
WHEN MATCHED THEN
    UPDATE SET
    [Id] = SOURCE.[Id],
    [Name] = SOURCE.[Name];