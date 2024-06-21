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

MERGE INTO ThemePark.LearningSpace_Templates AS TARGET
USING(VALUES
    ('f14d182d-52c5-4c82-81d4-6e2b87e854ab', 'Template 1', 10.5, 20.5, 15.0, '#66ffff', '#7e7b52', '#6fd156', 'b97112c7-5262-47a1-b62d-67d59f4b5bf6'),
    ('f8d87c1c-165f-4b2f-8052-168d5e8461a3', 'Template 2', 15.0, 25.0, 20.0, '#6fd156', '#7e7b52', '#ccff99', 'b97112c7-5262-47a1-b62d-67d59f4b5bf6'),
    ('9590db6d-a17d-4a98-8958-7e67bcd741e4', 'Template 3', 20.0, 30.0, 25.0, '#99ffff', '#ff9999', '#ccff99', 'b97112c7-5262-47a1-b62d-67d59f4b5bf6'),
    ('f2d92155-837a-40c7-a4c7-b15b7c290283', 'Template 4', 25.0, 35.0, 30.0, '#7e7b52', '#004d99', '#a6a6a6', 'e759d641-5f33-4968-a8b9-e6f1bb71fe0c'),
    ('f26408d5-975a-4ed8-b491-a50751fc8ec1', 'Template 5', 30.0, 40.0, 35.0, '#a6a6a6', '#004d99', '#99ffff', 'e759d641-5f33-4968-a8b9-e6f1bb71fe0c'),
    ('97528dc7-b085-48a8-9205-3a312eef0713', 'Template 6', 35.0, 45.0, 40.0, '#6fd156', '#7e7b52', '#ff9980', 'e759d641-5f33-4968-a8b9-e6f1bb71fe0c'),
    ('7b1ac2e9-a6b8-413b-95d4-6611a58549cc', 'Template 7', 40.0, 50.0, 45.0, '#ccff99', '#66ff66', '#67ff68', 'd0d5a703-3a28-493f-b286-46b0de9c8c05'),
    ('5fa93fdf-8158-4c92-867d-09086e879096', 'Template 8', 45.0, 55.0, 50.0, '#6fd156', '#66ff66', '#7e7b52', 'd0d5a703-3a28-493f-b286-46b0de9c8c05')
)
AS SOURCE (
    [Id],
    [TemplateName],
    [SizeX],
    [SizeY],
    [SizeZ],
    [FloorColor],
    [CeilingColor],
    [WallsColor],
    [Type]
)
ON TARGET.[Id] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
    INSERT (
        [Id],
        [TemplateName],
        [SizeX],
        [SizeY],
        [SizeZ],
        [FloorColor],
        [CeilingColor],
        [WallsColor],
        [Type]
    )
    VALUES (
        SOURCE.[Id],
        SOURCE.[TemplateName],
        SOURCE.[SizeX],
        SOURCE.[SizeY],
        SOURCE.[SizeZ],
        SOURCE.[FloorColor],
        SOURCE.[CeilingColor],
        SOURCE.[WallsColor],
        SOURCE.[Type]
    )
WHEN MATCHED THEN
    UPDATE SET
        [TemplateName] = SOURCE.[TemplateName],
        [SizeX] = SOURCE.[SizeX],
        [SizeY] = SOURCE.[SizeY],
        [SizeZ] = SOURCE.[SizeZ],
        [FloorColor] = SOURCE.[FloorColor],
        [CeilingColor] = SOURCE.[CeilingColor],
        [WallsColor] = SOURCE.[WallsColor],
        [Type] = SOURCE.[Type];
