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

MERGE INTO ThemePark.Projector AS Target
USING (VALUES
    ('Proyector 1', 1, 1, 0.0, 14, 0.0, 0.0, 0.0, 'd406ab33-140e-4b23-899d-c29acbbb2bc2'),

    ('Proyector 2', 1, 1, 6, 14, 0.0, 0.0, 0.0, 'd406ab33-140e-4b23-899d-c29acbbb2bc2' ),
    
    ('Proyector 3', 1, 1, 13, 14, 0.0, 0.0, 0.0, 'd406ab33-140e-4b23-899d-c29acbbb2bc2')

) AS SOURCE (
	[LearningComponentName],
	[SizeX],
	[SizeY],
	[PositionX],
	[PositionY],
	[PositionZ],
	[RotationX],
	[RotationY],
	[LearningSpaceId]
	)

ON TARGET.[LearningComponentName] = SOURCE.[LearningComponentName]
WHEN NOT MATCHED BY TARGET THEN
	INSERT (
		[LearningComponentName],
		[SizeX],
		[SizeY],
		[PositionX],
		[PositionY],
		[PositionZ],
		[RotationX],
		[RotationY],
		[LearningSpaceId])
	VALUES (
		
		SOURCE.[LearningComponentName],
		SOURCE.[SizeX],
		SOURCE.[SizeY],
		SOURCE.[PositionX],
		SOURCE.[PositionY],
		SOURCE.[PositionZ],
		SOURCE.[RotationX],
		SOURCE.[RotationY],
		SOURCE.[LearningSpaceId]
		)
	
WHEN MATCHED THEN
	UPDATE SET
	    [LearningComponentName] = SOURCE.[LearningComponentName],
		[SizeX] = SOURCE.[SizeX],
		[SizeY] =SOURCE.[SizeY],
		[PositionX] = SOURCE.[PositionX],
		[PositionY] = SOURCE.[PositionY],
		[PositionZ]= SOURCE.[PositionZ],
		[RotationX] = SOURCE.[RotationX],
		[RotationY] = SOURCE.[RotationY],
		[LearningSpaceId] = SOURCE.[LearningSpaceId];
