CREATE TABLE ThemePark.LevelHasDoors (
	LevelId UNIQUEIDENTIFIER,
	FOREIGN KEY (LevelId) 
		REFERENCES ThemePark.[Level](LevelId),
	DoorAssetId UNIQUEIDENTIFIER,
	FOREIGN KEY (DoorAssetId)
		REFERENCES ThemePark.DoorAsset(DoorAssetId),
	PRIMARY KEY (LevelId, DoorAssetId)
)