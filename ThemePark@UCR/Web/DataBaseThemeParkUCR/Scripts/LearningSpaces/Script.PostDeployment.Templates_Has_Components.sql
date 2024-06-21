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

MERGE INTO ThemePark.[Template_Has_Components] AS TARGET
USING(VALUES
    ('0f6ae2a6-011a-465a-be9c-0dc57e1abe30', 'InteractiveScreen', 'f14d182d-52c5-4c82-81d4-6e2b87e854ab', 1.0, 1.0, 3.0, 2.0, 0.0,0,0),
    ('5b9c082b-b20a-4911-aaf4-b9a5d94d8739', 'Projector', 'f8d87c1c-165f-4b2f-8052-168d5e8461a3', 2.0, 1.5, 2.0, 2.0, 2.0,0,0),
    ('1016f3a9-e067-4297-a3a0-3276785727b0', 'Whiteboard', '9590db6d-a17d-4a98-8958-7e67bcd741e4', 3.0, 2.0, 5.0, 4.0, 3.0,0,0),
    ('f2e0b69a-6c02-4c97-b8d6-303257824ad4', 'Projector', 'f2d92155-837a-40c7-a4c7-b15b7c290283', 4.0, 2.0, 1.0, 2.0, 2.0,0,0)
)
AS SOURCE (
    [Id],
    [Component_type],
    [Template],
    [SizeX],
    [SizeY],
    [PositionX],
    [PositionY],
    [PositionZ],
    [RotationX],
    [RotationY]
)
ON TARGET.[Id] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
    INSERT (
        [Id],
        [Component_type],
        [Template],
        [SizeX],
        [SizeY],
        [PositionX],
        [PositionY],
        [PositionZ],
        [RotationX],
        [RotationY]
    )
    VALUES (
        SOURCE.[Id],
        SOURCE.[Component_type],
        SOURCE.[Template],
        SOURCE.[SizeX],
        SOURCE.[SizeY],
        SOURCE.[PositionX],
        SOURCE.[PositionY],
        SOURCE.[PositionZ],
        SOURCE.[RotationX],
        SOURCE.[RotationY]
    )
WHEN MATCHED THEN
    UPDATE SET
        [Component_type] = SOURCE.[Component_type],
        [Template] = SOURCE.[Template],
        [SizeX] = SOURCE.[SizeX],
        [SizeY] = SOURCE.[SizeY],
        [PositionX] = SOURCE.[PositionX],
        [PositionY] = SOURCE.[PositionY],
        [PositionZ]  = SOURCE.[PositionZ],
        [RotationX] = SOURCE.[RotationX],
        [RotationY] = SOURCE.[RotationY];