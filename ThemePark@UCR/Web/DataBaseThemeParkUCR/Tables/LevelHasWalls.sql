CREATE TABLE ThemePark.LevelHasWalls (
	LevelId UNIQUEIDENTIFIER,
	FOREIGN KEY (LevelId) 
		REFERENCES ThemePark.[Level](LevelId),
	WallAssetId UNIQUEIDENTIFIER,
	FOREIGN KEY (WallAssetId)
		REFERENCES ThemePark.WallAsset(WallAssetId),
	PRIMARY KEY (LevelId, WallAssetId)
)