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

MERGE INTO ThemePark.LearningSpace AS Target
USING (VALUES
	('d406ab33-140e-4b23-899d-c29acbbb2bc2', 'b43f7220-f53f-426b-a588-6f500a845a14', 'IF-201', 15, 15, 15, '#7e7b52', '#ffffff', '#ffffff', 'd0d5a703-3a28-493f-b286-46b0de9c8c05'),
	('37c0a8b0-6883-4986-bd49-59daf6d18c97', 'b43f7220-f53f-426b-a588-6f500a845a14', 'IF-301', 7, 8, 8, '#7e7b52', '#ffffff', '#ffffff', 'b97112c7-5262-47a1-b62d-67d59f4b5bf6'),
	('1e44f1dc-360d-4307-8b53-98a1ea25f467', 'a90059f3-5253-4ea4-b4ee-04af135e839d', 'IF-3-1', 3, 6, 3, '#7e7b52', '#ffffff', '#ffffff', 'd0d5a703-3a28-493f-b286-46b0de9c8c05'),
	('b6be82fc-5283-44d5-93df-6b42b9a124a4', 'a90059f3-5253-4ea4-b4ee-04af135e839d', 'IF-3-2', 5, 7, 4, '#7e7b52', '#66ffff', '#ffffff', 'e759d641-5f33-4968-a8b9-e6f1bb71fe0c'),
	('7c705758-5ea9-4a6b-94d1-de42320bb695', '61de8e2d-f92a-45b9-a22f-2b63ae460900', 'IF-4-1', 5, 7, 4, '#7e7b52', '#ff55ff', '#ffffff', 'b97112c7-5262-47a1-b62d-67d59f4b5bf6'),
	('148bdedb-0b8f-4453-af82-cee6edd2bac7', 'c022a684-fbca-4f0a-aa1c-1aaeb45c6723', 'IF-4-2', 5, 7, 4, '#7e7b52', '#ffaaff', '#ff5fff', 'b97112c7-5262-47a1-b62d-67d59f4b5bf6'),
    ('9363db14-cb58-4f29-8bfb-350256862f37', '61de8e2d-f92a-45b9-a22f-2b63ae460900', 'EF-1-2', 20, 25, 10, '#f5d142', '#42f5b0', '#fc7ebd', 'b97112c7-5262-47a1-b62d-67d59f4b5bf6'),
    ('f8010e73-691c-4d6e-bcdd-c94a4fb2a129', 'c022a684-fbca-4f0a-aa1c-1aaeb45c6723', 'EF-3-4', 40,45,21, '#5660d1', '#56d1c7', '#6fd156', 'b97112c7-5262-47a1-b62d-67d59f4b5bf6'),
    ('4d7445e6-3c38-4290-9a3a-69beac9b03c5', 'b43f7220-f53f-426b-a588-6f500a845a14', 'EF-5-6', 30,35,10, '#5660d1', '#56d1c7', '#6fd156', 'b97112c7-5262-47a1-b62d-67d59f4b5bf6')
)
AS SOURCE (
    [LearningSpaceId],
    [LevelId],
    [LearningSpaceName],
    [SizeX],
    [SizeY],
    [SizeZ],
    [FloorColor],
    [CeilingColor],
    [WallsColor],
    [Type])
ON TARGET.[LearningSpaceId] = SOURCE.[LearningSpaceId]
WHEN NOT MATCHED BY TARGET THEN
    INSERT (
        [LearningSpaceId],
        [LevelId],
        [LearningSpaceName],
        [SizeX],
        [SizeY],
        [SizeZ],
        [FloorColor],
        [CeilingColor],
        [WallsColor],
        [Type]
        )
    VALUES (
        SOURCE.[LearningSpaceId],
        SOURCE.[LevelId],
        SOURCE.[LearningSpaceName],
        SOURCE.[SizeX],
        SOURCE.[SizeY],
        SOURCE.[SizeZ],
        SOURCE.[FloorColor],
        SOURCE.[CeilingColor],
        SOURCE.[WallsColor],
        SOURCE.[Type])

WHEN MATCHED THEN
    UPDATE SET
        [LevelId] = SOURCE.[LevelId],
        [LearningSpaceName] = SOURCE.[LearningSpaceName],
        [SizeX] = SOURCE.[SizeX],
        [SizeY] = SOURCE.[SizeY],
        [SizeZ] = SOURCE.[SizeZ],
        [FloorColor] = SOURCE.[FloorColor],
        [CeilingColor] = SOURCE.[CeilingColor],
        [WallsColor] = SOURCE.[WallsColor],
        [Type] = SOURCE.[Type];
