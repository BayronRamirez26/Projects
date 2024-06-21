CREATE TABLE ThemePark.[Level] (
	LevelId UNIQUEIDENTIFIER,
	CONSTRAINT PK_LEVEL PRIMARY KEY (LevelId),
	UniversityName VARCHAR(255) NOT NULL,
	CampusName VARCHAR(255) NOT NULL,
	SiteName VARCHAR(127) NOT NULL,
	BuildingAcronym VARCHAR(10) NOT NULL,
	CONSTRAINT FK_BUILDING FOREIGN KEY (UniversityName, CampusName, SiteName, BuildingAcronym) 
		REFERENCES ThemePark.Building(UniversityName, CampusName, SiteName, BuildingAcronym)
		ON DELETE CASCADE,
	LevelNumber TINYINT,
	SizeX FLOAT NOT NULL,
	SizeY FLOAT NOT NULL,
	SizeZ FLOAT NOT NULL,
	LearningSpaceCount TINYINT,
	FloorAssetId UNIQUEIDENTIFIER,
	FOREIGN KEY (FloorAssetId)
		REFERENCES ThemePark.FloorAsset(FloorAssetId),
	CeilingAssetId UNIQUEIDENTIFIER,
	FOREIGN KEY (CeilingAssetId)
		REFERENCES ThemePark.CeilingAsset(CeilingAssetId)
)