CREATE TABLE ThemePark.LevelHasStairs (
	LevelId UNIQUEIDENTIFIER,
	FOREIGN KEY (LevelId) 
		REFERENCES ThemePark.[Level](LevelId),
	StairsAssetId UNIQUEIDENTIFIER,
	FOREIGN KEY (StairsAssetId)
		REFERENCES ThemePark.StairsAsset(StairsAssetId),
	PRIMARY KEY (LevelId, StairsAssetId)
)