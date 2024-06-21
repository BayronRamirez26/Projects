/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO ThemePark.LearningComponent AS Target
USING (VALUES
    ( '9c746694-0558-44b7-9e55-c75da02e479d','Whiteboard',0.0,0.0,0.0,0.0,0.0),
  
    ('b8674ba8-21a4-4426-9ab4-7e1ae3be3859', 'Keyboard',0.0,0.0,0.0,0.0,0.0),

   ('35dc84d9-da84-477f-ba67-f7d4843a4ac1', 'Computer',0.0,0.0,0.0,0.0,0.0)
) AS SOURCE (
    [LearningComponentAssetId],
    [LearningComponentType],

    [SizeX],
    [SizeY],
    [PositionX],
    [PositionY],
    [PositionZ]
)
ON TARGET.[LearningComponentAssetId] = SOURCE.[LearningComponentAssetId]
WHEN MATCHED THEN
    UPDATE SET
        [LearningComponentType] = SOURCE.[LearningComponentType],
        [SizeX] = SOURCE.[SizeX],
        [SizeY] = SOURCE.[SizeY],
        [PositionX] = SOURCE.[PositionX],
        [PositionY] = SOURCE.[PositionY],
        [PositionZ] = SOURCE.[PositionZ]
WHEN NOT MATCHED BY TARGET THEN
    INSERT (
        [LearningComponentAssetId],
        [LearningComponentType],
        [SizeX],
        [SizeY],
        [PositionX],
        [PositionY],
        [PositionZ]
    )
    VALUES (
        SOURCE.[LearningComponentAssetId],
        SOURCE.[LearningComponentType],
        SOURCE.[SizeX],
        SOURCE.[SizeY],
        SOURCE.[PositionX],
        SOURCE.[PositionY],
        SOURCE.[PositionZ]
    );