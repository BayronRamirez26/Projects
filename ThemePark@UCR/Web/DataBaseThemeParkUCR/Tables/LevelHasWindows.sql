CREATE TABLE ThemePark.LevelHasWindows (
	LevelId UNIQUEIDENTIFIER,
	FOREIGN KEY (LevelId) 
		REFERENCES ThemePark.[Level](LevelId),
	WindowAssetId UNIQUEIDENTIFIER,
	FOREIGN KEY (WindowAssetId)
		REFERENCES ThemePark.WindowAsset(WindowAssetId),
	PRIMARY KEY (LevelId, WindowAssetId)
)