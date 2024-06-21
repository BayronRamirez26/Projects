CREATE TABLE ThemePark.LevelHasDecorations (
	LevelId UNIQUEIDENTIFIER,
	FOREIGN KEY (LevelId) 
		REFERENCES ThemePark.[Level](LevelId),
	DecorationAssetId UNIQUEIDENTIFIER,
	FOREIGN KEY (DecorationAssetId)
		REFERENCES ThemePark.DecorationAsset(DecorationAssetId),
	PRIMARY KEY (LevelId, DecorationAssetId)
)