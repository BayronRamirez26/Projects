CREATE TABLE [ThemePark].[AccessPoint]
(
	[AccessPointId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[LearningSpaceId] UNIQUEIDENTIFIER,
	[LevelId] UNIQUEIDENTIFIER,
	--FOREIGN KEY (LearningSpaceId)
	--	REFERENCES ThemePark.LearningSpace(LearningSpaceId),
	--FOREIGN KEY (LevelId)
	--	REFERENCES ThemePark.Level(LevelId)
)
