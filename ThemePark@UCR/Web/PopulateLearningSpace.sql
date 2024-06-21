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


MERGE INTO ThemePark.Site AS Target
USING (VALUES
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 0, 0),
	('Universidad de Costa Rica', 'Sede Occidente', 'Finca 1', 0, 0),
	('Universidad de Costa Rica', 'Sede recinto Tacares', 'Finca 1', 0, 0)
)
AS SOURCE ([UniversityName], [CampusNameBuffer],[SiteNameBuffer], [SiteSizeXBuffer], [SiteSizeYBuffer])
ON TARGET.[UniversityName] = SOURCE.[UniversityName]
AND [CampusName] = SOURCE.[CampusNameBuffer]
AND [SiteName] = SOURCE.[SiteNameBuffer]
AND [SiteSizeX] = SOURCE.[SiteSizeXBuffer]
AND [SiteSizeY] = SOURCE.[SiteSizeYBuffer]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UniversityName], [CampusName], SiteName, SiteSizeX, SiteSizeY)

		VALUES (SOURCE.[UniversityName], SOURCE.[CampusNameBuffer], SOURCE.[SiteNameBuffer], SOURCE.[SiteSizeXBuffer], SOURCE.[SiteSizeYBuffer])
WHEN MATCHED THEN
	UPDATE SET
		[UniversityName] = SOURCE.[UniversityName],
		[CampusName] = SOURCE.[CampusNameBuffer],
		[SiteName] = SOURCE.[SiteNameBuffer],
		[SiteSizeX] = SOURCE.[SiteSizeXBuffer],
		[SiteSizeY] = SOURCE.[SiteSizeYBuffer];


MERGE INTO ThemePark.Building AS Target
USING (VALUES
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI Anexo', 'Edificio anexo de la ECCI', 0, 0, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 'Edificio viejo de la ECCI', 0, 0, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede Occidente', 'Finca 1', 'AQ', 'Edificio numero 255', 0, 0, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede recinto Tacares', 'Finca 1', 'IE', 'Edificio importante numero 2', 0, 0, 0, 0, 0)
)
AS SOURCE ([UniversityNameBuffer], [CampusNameBuffer], [SiteNameBuffer],[BuildingAcronymBuffer], [BuildingNameBuffer], [CoordinateXBuffer], [CoordinateYBuffer], [SizeXBuffer], [SizeYBuffer], [RotationBuffer]) -- , [LevelCount]
ON TARGET.[UniversityName] = SOURCE.[UniversityNameBuffer]
AND [CampusName] = SOURCE.[CampusNameBuffer]
AND [SiteName] = SOURCE.[SiteNameBuffer]
AND [BuildingAcronym] = SOURCE.[BuildingAcronymBuffer]
AND [BuildingName] = SOURCE.[BuildingNameBuffer]
AND [CoordinateX] = SOURCE. [CoordinateXBuffer]
AND [CoordinateY] = SOURCE.[CoordinateYBuffer]
AND [SizeX] = SOURCE.[SizeXBuffer]
AND [SizeY] = SOURCE.[SizeYBuffer]
AND [Rotation] = SOURCE.[RotationBuffer]

WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UniversityName], [CampusName], [SiteName],[BuildingAcronym], [BuildingName], [CoordinateX], [CoordinateY], [SizeX], [SizeY], [Rotation])

		VALUES (SOURCE.[UniversityNameBuffer], SOURCE.[CampusNameBuffer], SOURCE.[SiteNameBuffer], SOURCE.[BuildingAcronymBuffer], SOURCE.[BuildingNameBuffer], SOURCE.[CoordinateXBuffer], SOURCE.[CoordinateYBuffer], SOURCE.[SizeXBuffer], SOURCE.[SizeYBuffer], SOURCE.[RotationBuffer])

WHEN MATCHED THEN
	UPDATE SET
		[UniversityName] = SOURCE.[UniversityNameBuffer],
		[CampusName] = SOURCE.[CampusNameBuffer],
		[SiteName] = SOURCE.[SiteNameBuffer],
		[BuildingAcronym] = SOURCE.[BuildingAcronymBuffer],
		[BuildingName] = SOURCE.[BuildingNameBuffer],
		[CoordinateX] = SOURCE.[CoordinateXBuffer],
		[CoordinateY] = SOURCE.[CoordinateYBuffer],
		[SizeX] = SOURCE.[SizeXBuffer],
		[SizeY] = SOURCE.[SizeYBuffer],
		[Rotation] = SOURCE.[RotationBuffer];

MERGE INTO ThemePark.Level AS Target
USING (VALUES
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI Anexo', 04, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 03, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede Occidente', 'Finca 1', 'AQ', 02, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede recinto Tacares', 'Finca 1', 'IE', 02, 0, 0, 0),
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 01, 0, 0, 0)
)
AS SOURCE ([UniversityNameBuffer], [CampusNameBuffer], [SiteNameBuffer],[BuildingAcronymBuffer], [LevelNumberBuffer], [SizeXBuffer], [SizeYBuffer], [SizeZBuffer])
ON TARGET.[UniversityName] = SOURCE.[UniversityNameBuffer]
AND [CampusName] = SOURCE.[CampusNameBuffer]
AND [SiteName] = SOURCE.[SiteNameBuffer]
AND [BuildingAcronym] = SOURCE.[BuildingAcronymBuffer]
AND [LevelNumber] = SOURCE.[LevelNumberBuffer]
AND [SizeX] = SOURCE.[SizeXBuffer]
AND [SizeY] = SOURCE.[SizeYBuffer]
AND [SizeZ] = SOURCE.[SizeZBuffer]

WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UniversityName], [CampusName], [SiteName],[BuildingAcronym], [LevelNumber], [SizeX], [SizeY], [SizeZ])

		VALUES (SOURCE.[UniversityNameBuffer], SOURCE.[CampusNameBuffer], SOURCE.[SiteNameBuffer], SOURCE.[BuildingAcronymBuffer], SOURCE.[LevelNumberBuffer], SOURCE.[SizeXBuffer], SOURCE.[SizeYBuffer], SOURCE.[SizeZBuffer] )
WHEN MATCHED THEN
	UPDATE SET
		[UniversityName] = SOURCE.[UniversityNameBuffer],
		[CampusName] = SOURCE.[CampusNameBuffer],
		[SiteName] = SOURCE.[SiteNameBuffer],
		[BuildingAcronym] = SOURCE.[BuildingAcronymBuffer],
		[LevelNumber] = SOURCE.[LevelNumberBuffer],
		[SizeX] = SOURCE.[SizeXBuffer],
		[SizeY] = SOURCE.[SizeYBuffer],
		[SizeZ] = SOURCE.[SizeZBuffer];

MERGE INTO ThemePark.LearningSpace AS Target
USING (VALUES
    ('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI Anexo', 04, 06, 'aula0', 4, 7, 5,'64abe13e-dc07-4883-be7d-1d195978bf88', 'b0364b8f-5d80-4223-b7e7-0819ca497b41', '#46010b', '#eee6dd', '#ff93ac'), --, '64abe13e-dc07-4883-be7d-1d195978bf88', 'b0364b8f-5d80-4223-b7e7-0819ca497b41', 
    ('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 03, 04, 'aula1', 7, 8, 8, '4ad5abfe-35c3-4152-8d9c-95f55130e17c', 'ebcf3d0c-3caf-40f4-87e7-2f93d4a1456c', '#d4e1b8', '#f4f8b3', '#c0d6e4'), -- '4ad5abfe-35c3-4152-8d9c-95f55130e17c', 'ebcf3d0c-3caf-40f4-87e7-2f93d4a1456c',
    ('Universidad de Costa Rica', 'Sede Occidente', 'Finca 1', 'AQ', 02, 04, 'aula2', 3, 6, 3, '3c56ba38-2ed4-4a71-99f9-107b72b7dbdf', 'e5720fc3-faf0-468b-864b-cac34ea622d7', 'b3d4cf', '#b6c0d0', '#ffdead'), --'3c56ba38-2ed4-4a71-99f9-107b72b7dbdf', 'e5720fc3-faf0-468b-864b-cac34ea622d7', 
    ('Universidad de Costa Rica', 'Sede recinto Tacares', 'Finca 1', 'IE', 02, 04, 'aula3', 5, 7, 4, '1cbe4796-5330-4879-9a2f-07ec28e5cbfa', '4699b100-7bd2-4b00-86b7-9f76a41f2877', 'b3d4cf', '#b6c0d0', '#ffdead'), --, '1cbe4796-5330-4879-9a2f-07ec28e5cbfa', '4699b100-7bd2-4b00-86b7-9f76a41f2877',
    ('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 01, 04, 'aula4', 3, 4, 6, '04e9d67f-45fb-4243-bc4d-701d7058a262', 'eb587bb0-42c7-47a6-9b33-45180f4c4236', '#3f4f4c', '#819090', '#8b6969') --, '04e9d67f-45fb-4243-bc4d-701d7058a262', 'eb587bb0-42c7-47a6-9b33-45180f4c4236'
)
AS SOURCE ([UniversityNameBuffer], [CampusNameBuffer], [SiteNameBuffer],[BuildingAcronymBuffer], [LevelNumberBuffer], [LearningSpaceIdBuffer], [LearningSpaceNameBuffer], [SizeXBuffer], [SizeYBuffer], [SizeZBuffer], [FloorAssetIdBuffer], [CeilingAssetIdBuffer] ,[FloorColorBuffer], [CeilingColorBuffer], [WallsColorBuffer]) -- [FloorAssetId], [CeilingAssetId], 
ON TARGET.[UniversityName] = SOURCE.[UniversityNameBuffer]
AND TARGET.[CampusName] = SOURCE.[CampusNameBuffer]
AND TARGET.[SiteName] = SOURCE.[SiteNameBuffer]
AND TARGET.[BuildingAcronym] = SOURCE.[BuildingAcronymBuffer]
AND TARGET.[LevelNumber] = SOURCE.[LevelNumberBuffer]
AND TARGET.[LearningSpaceName] = SOURCE.[LearningSpaceNameBuffer]
AND TARGET.[SizeX] = SOURCE.[SizeXBuffer]
AND TARGET.[SizeY] = SOURCE.[SizeYBuffer]
AND TARGET.[SizeZ] = SOURCE.[SizeZBuffer]
AND TARGET.[FloorAssetId] = SOURCE.[FloorAssetIdBuffer]
AND TARGET.[CeilingAssetId] = SOURCE.[CeilingAssetIdBuffer]
AND TARGET.[FloorColor] = SOURCE.[FloorColorBuffer]
AND TARGET.[CeilingColor] = SOURCE.[CeilingColorBuffer]
AND TARGET.[WallsColor] =  SOURCE.[WallsColorBuffer]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([UniversityName], [CampusName], [SiteName],[BuildingAcronym], [LevelNumber], [LearningSpaceId], [LearningSpaceName], [SizeX], [SizeY], [SizeZ], [FloorAssetId], [CeilingAssetId] ,[FloorColor], [CeilingColor], [WallsColor])
    VALUES (SOURCE.[UniversityNameBuffer], SOURCE.[CampusNameBuffer], SOURCE.[SiteNameBuffer], SOURCE.[BuildingAcronymBuffer], SOURCE.[LevelNumberBuffer], SOURCE.[LearningSpaceIdBuffer], SOURCE.[LearningSpaceNameBuffer], SOURCE.[SizeXBuffer], SOURCE.[SizeYBuffer], SOURCE.[SizeZBuffer], SOURCE.[FloorAssetIdBuffer], SOURCE.[CeilingAssetIdBuffer], SOURCE.[FloorColorBuffer], SOURCE.[CeilingColorBuffer], SOURCE.[WallsColorBuffer])
WHEN MATCHED THEN
    UPDATE SET
        TARGET.[UniversityName] = SOURCE.[UniversityNameBuffer],
        TARGET.[CampusName] = SOURCE.[CampusNameBuffer],
        TARGET.[SiteName] = SOURCE.[SiteNameBuffer],
        TARGET.[BuildingAcronym] = SOURCE.[BuildingAcronymBuffer],
        TARGET.[LevelNumber] = SOURCE.[LevelNumberBuffer],
        TARGET.[LearningSpaceId] = SOURCE.[LearningSpaceIdBuffer],
        TARGET.[LearningSpaceName] = SOURCE.[LearningSpaceNameBuffer],
        TARGET.[SizeX] = SOURCE.[SizeXBuffer],
        TARGET.[SizeY] = SOURCE.[SizeYBuffer],
        TARGET.[SizeZ] = SOURCE.[SizeZBuffer],
        TARGET.[FloorAssetId] = SOURCE.[FloorAssetIdBuffer],
        TARGET.[CeilingAssetId] = SOURCE.[CeilingAssetIdBuffer],
        --TARGET.[FloorAssetId] = SOURCE.[FloorAssetId],
        --TARGET.[CeilingAssetId] = SOURCE.[CeilingAssetId],
        TARGET.[FloorColor] = SOURCE.[FloorColorBuffer],
        TARGET.[CeilingColor] = SOURCE.[CeilingColorBuffer],
        TARGET.[WallsColor] = SOURCE.[WallsColorBuffer];

MERGE INTO ThemePark.Classroom AS Target
USING (VALUES
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI Anexo', 04, 06),
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 03, 04),
	('Universidad de Costa Rica', 'Sede Occidente', 'Finca 1', 'AQ', 02, 04),
	('Universidad de Costa Rica', 'Sede recinto Tacares', 'Finca 1', 'IE', 02, 04),
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 01, 04)
)
AS SOURCE ([UniversityNameBuffer], [CampusNameBuffer], [SiteNameBuffer],[BuildingAcronymBuffer], [LevelNumberBuffer], [LearningSpaceIdBuffer])
ON TARGET.[UniversityName] = SOURCE.[UniversityNameBuffer]
AND [CampusName] = SOURCE.[CampusNameBuffer]
AND [SiteName] = SOURCE.[SiteNameBuffer]
AND [BuildingAcronym] = SOURCE.[BuildingAcronymBuffer]
AND [LevelNumber] = SOURCE.[LevelNumberBuffer]
AND [LearningSpaceId] = SOURCE.[LearningSpaceIdBuffer]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UniversityName], [CampusName], [SiteName],[BuildingAcronym], [LevelNumber], [LearningSpaceId])
		VALUES (SOURCE.[UniversityNameBuffer], SOURCE.[CampusNameBuffer], SOURCE.[SiteNameBuffer], SOURCE.[BuildingAcronymBuffer], SOURCE.[LevelNumberBuffer], SOURCE.[LearningSpaceIdBuffer])
WHEN MATCHED THEN
	UPDATE SET
		[UniversityName] = SOURCE.[UniversityNameBuffer],
		[CampusName] = SOURCE.[CampusNameBuffer],
		[SiteName] = SOURCE.[SiteNameBuffer],
		[BuildingAcronym] = SOURCE.[BuildingAcronymBuffer],
		[LevelNumber] = SOURCE.[LevelNumberBuffer],
		[LearningSpaceId] = SOURCE.[LearningSpaceIdBuffer];

MERGE INTO ThemePark.Laboratory AS Target
USING (VALUES
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI Anexo', 04, 06),
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 03, 04),
	('Universidad de Costa Rica', 'Sede Occidente', 'Finca 1', 'AQ', 02, 04),
	('Universidad de Costa Rica', 'Sede recinto Tacares', 'Finca 1', 'IE', 02, 04),
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 01, 04)
)
AS SOURCE ([UniversityNameBuffer], [CampusNameBuffer], [SiteNameBuffer],[BuildingAcronymBuffer], [LevelNumberBuffer], [LearningSpaceIdBuffer])
ON TARGET.[UniversityName] = SOURCE.[UniversityNameBuffer]
AND [CampusName] = SOURCE.[CampusNameBuffer]
AND [SiteName] = SOURCE.[SiteNameBuffer]
AND [BuildingAcronym] = SOURCE.[BuildingAcronymBuffer]
AND [LevelNumber] = SOURCE.[LevelNumberBuffer]
AND [LearningSpaceId] = SOURCE.[LearningSpaceIdBuffer]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UniversityName], [CampusName], [SiteName],[BuildingAcronym], [LevelNumber], [LearningSpaceId])
		VALUES (SOURCE.[UniversityNameBuffer], SOURCE.[CampusNameBuffer], SOURCE.[SiteNameBuffer], SOURCE.[BuildingAcronymBuffer], SOURCE.[LevelNumberBuffer], SOURCE.[LearningSpaceIdBuffer])
WHEN MATCHED THEN
	UPDATE SET
		[UniversityName] = SOURCE.[UniversityNameBuffer],
		[CampusName] = SOURCE.[CampusNameBuffer],
		[SiteName] = SOURCE.[SiteNameBuffer],
		[BuildingAcronym] = SOURCE.[BuildingAcronymBuffer],
		[LevelNumber] = SOURCE.[LevelNumberBuffer],
		[LearningSpaceId] = SOURCE.[LearningSpaceIdBuffer];

MERGE INTO ThemePark.Auditorium AS Target
USING (VALUES
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI Anexo', 04, 06),
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 03, 04),
	('Universidad de Costa Rica', 'Sede Occidente', 'Finca 1', 'AQ', 02, 04),
	('Universidad de Costa Rica', 'Sede recinto Tacares', 'Finca 1', 'IE', 02, 04),
	('Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI-O', 01, 04)
)
AS SOURCE ([UniversityNameBuffer], [CampusNameBuffer], [SiteNameBuffer],[BuildingAcronymBuffer], [LevelNumberBuffer], [LearningSpaceIdBuffer])
ON TARGET.[UniversityName] = SOURCE.[UniversityNameBuffer]
AND [CampusName] = SOURCE.[CampusNameBuffer]
AND [SiteName] = SOURCE.[SiteNameBuffer]
AND [BuildingAcronym] = SOURCE.[BuildingAcronymBuffer]
AND [LevelNumber] = SOURCE.[LevelNumberBuffer]
AND [LearningSpaceId] = SOURCE.[LearningSpaceIdBuffer]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UniversityName], [CampusName], [SiteName],[BuildingAcronym], [LevelNumber], [LearningSpaceId])
		VALUES (SOURCE.[UniversityNameBuffer], SOURCE.[CampusNameBuffer], SOURCE.[SiteNameBuffer], SOURCE.[BuildingAcronymBuffer], SOURCE.[LevelNumberBuffer], SOURCE.[LearningSpaceIdBuffer])
WHEN MATCHED THEN
	UPDATE SET
		[UniversityName] = SOURCE.[UniversityNameBuffer],
		[CampusName] = SOURCE.[CampusNameBuffer],
		[SiteName] = SOURCE.[SiteNameBuffer],
		[BuildingAcronym] = SOURCE.[BuildingAcronymBuffer],
		[LevelNumber] = SOURCE.[LevelNumberBuffer],
		[LearningSpaceId] = SOURCE.[LearningSpaceIdBuffer];
