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

MERGE INTO ThemePark.[LearningSpaceType] AS TARGET
USING(VALUES
    ('b97112c7-5262-47a1-b62d-67d59f4b5bf6', 'Aula'),
    ('e759d641-5f33-4968-a8b9-e6f1bb71fe0c', 'Laboratorio'),
    ('d0d5a703-3a28-493f-b286-46b0de9c8c05', 'Auditorio'),
    ('a144124d-9f71-464f-860c-2d8d1bceaad6', 'Gimnasio'),
    ('4ce0efaf-b469-4432-9222-e1eb7e391834', 'Sala de Baile'),
    ('a51bf492-e66f-4535-8850-0ed8982e4fd6', 'Taller de Arte'),
    ('5452b932-6ed1-4c9a-ac14-4a55713b9e84', 'Laboratorio de Química'),
    ('d288fb63-4f97-41c0-89c7-3c3cf8fbbdad', 'Sala de Proyecciones')

)
AS SOURCE (
    [Id],
    [Name]
)
ON TARGET.[Id] = SOURCE.Id
WHEN NOT MATCHED BY TARGET THEN
    INSERT (
        [Id],
        [Name]
    )
    VALUES (
        SOURCE.[Id],
        SOURCE.[Name]
    )
WHEN MATCHED THEN
    UPDATE SET
        [Id] = SOURCE.[Id],
        [Name] = SOURCE.[Name];
