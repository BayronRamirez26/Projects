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

MERGE INTO ThemePark.[Level] AS Target
USING (VALUES
	('b43f7220-f53f-426b-a588-6f500a845a14', 'Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCIAnexo', 01, 20, 10, 2, 5, '0b4023f6-3017-4b0e-b674-4384580b5538', '12a279e3-2df2-47b9-9e23-bdbcbcca3141'),
	('a90059f3-5253-4ea4-b4ee-04af135e839d', 'Universidad de Costa Rica', 'Sede Rodrigo Facio', 'Finca 1', 'ECCI', 01, 20, 10, 2, 05, '18cb0976-1d75-45dc-8be2-8d05f431154e','f7dfc9e2-c048-48a2-93a5-1004b3fb5fb2'),
	('61de8e2d-f92a-45b9-a22f-2b63ae460900', 'Universidad de Costa Rica', 'Sede Occidente', 'Finca 1', 'AQ', 01, 20, 10, 2, 05, 'a5e3ffbf-4be9-4bbb-831d-5013f5de0663', '2533013d-68e1-4849-b077-dab128d8ff1c'),
	('c022a684-fbca-4f0a-aa1c-1aaeb45c6723', 'Universidad de Costa Rica', 'Sede recinto Tacares', 'Finca 1', 'IE', 01, 20, 10, 2, 05,'9f9df5a3-9426-454d-a489-7cbc1e893905','b74f6b3f-7fc1-4cfb-9945-d0998342c05d')
)
AS SOURCE ([LevelId], [UniversityName], [CampusName], [SiteName],[BuildingAcronym], [LevelNumber], [SizeX], 
	[SizeY], [SizeZ], [LearningSpaceCount], [FloorAssetId], [CeilingAssetId])
ON TARGET.[LevelId] = SOURCE.[LevelId]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([LevelId], [UniversityName], [CampusName], [SiteName], [BuildingAcronym], [LevelNumber], [SizeX], [SizeY], [SizeZ], 
			[LearningSpaceCount], [FloorAssetId], [CeilingAssetId])
		VALUES (SOURCE.[LevelId], SOURCE.[UniversityName], SOURCE.[CampusName], SOURCE.[SiteName], SOURCE.[BuildingAcronym], SOURCE.[LevelNumber], 
			SOURCE.[SizeX], SOURCE.[SizeY], SOURCE.[SizeZ], SOURCE.[LearningSpaceCount], SOURCE.[FloorAssetId], SOURCE.[CeilingAssetId])
WHEN MATCHED THEN
	UPDATE SET
		[LevelNumber] = SOURCE.[LevelNumber],
		[SizeX] = SOURCE.[SizeX],
		[SizeY] = SOURCE.[SizeY],
		[SizeZ] = SOURCE.[SizeZ],
		[LearningSpaceCount] = SOURCE.[LearningSpaceCount],
		[FloorAssetId] = SOURCE.[FloorAssetId],
		[CeilingAssetId] = SOURCE.[CeilingAssetId];
