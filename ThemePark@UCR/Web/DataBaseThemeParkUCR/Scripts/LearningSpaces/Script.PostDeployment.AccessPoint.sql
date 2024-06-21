
MERGE INTO ThemePark.[AccessPoint] AS TARGET
USING(VALUES
	('51d2fe50-37af-45b6-9cf2-7a90fc2719f6', 'd406ab33-140e-4b23-899d-c29acbbb2bc2', 'b43f7220-f53f-426b-a588-6f500a845a14', 5, 0, 7.3, 0,90),
	('82d832be-bd27-4bce-8bf0-a32b2456933a', '37c0a8b0-6883-4986-bd49-59daf6d18c97', 'b43f7220-f53f-426b-a588-6f500a845a14', 5, 8, 3, 0,0),
	('3503eb0a-89d7-493c-bdd4-66ce04dcf377', '148bdedb-0b8f-4453-af82-cee6edd2bac7', 'c022a684-fbca-4f0a-aa1c-1aaeb45c6723', 5,2,3, 0,0),
	('fb4acb27-b15e-4de7-b849-4eeaebace5cf', '9363db14-cb58-4f29-8bfb-350256862f37', '61de8e2d-f92a-45b9-a22f-2b63ae460900', 4,7,2, 0,0),
	('b8f63cef-d8fa-40ac-91b5-651e0c35574f', 'f8010e73-691c-4d6e-bcdd-c94a4fb2a129', 'c022a684-fbca-4f0a-aa1c-1aaeb45c6723', 3,7,9, 0,0),
	('e26e1a25-cfbf-4012-b4bc-25c7141e9f96','4d7445e6-3c38-4290-9a3a-69beac9b03c5', 'b43f7220-f53f-426b-a588-6f500a845a14',9,6,3, 0,0)
)
AS SOURCE (
	[AccessPointId],
	[LearningSpaceId],
	[LevelId],
	[CoordX],
	[CoordY],
	[CoordZ],
	[RotationX],
	[RotationY]
)
ON TARGET.[AccessPointId] = SOURCE.AccessPointId
WHEN NOT MATCHED BY TARGET THEN
	INSERT (
		[AccessPointId],
		[LearningSpaceId],
		[LevelId],
		[CoordX],
		[CoordY],
		[CoordZ],
		[RotationX],
		[RotationY]
	)
	VALUES (
		SOURCE.[AccessPointId],
		SOURCE.[LearningSpaceId],
		SOURCE.[LevelId],
		SOURCE.[CoordX],
		SOURCE.[CoordY],
		SOURCE.[CoordZ],
		SOURCE.[RotationX],
		SOURCE.[RotationY]
	)
WHEN MATCHED THEN
	UPDATE SET
		[AccessPointId] = SOURCE.[AccessPointId],
		[LearningSpaceId] = SOURCE.[LearningSpaceId],
		[LevelId] = SOURCE.[LevelId],
		[CoordX] = SOURCE.[CoordX],
		[CoordY] = SOURCE.[CoordY],
		[CoordZ] = SOURCE.[CoordZ],
		[RotationX] = SOURCE.[RotationX],
		[RotationY] = SOURCE.[RotationY];
