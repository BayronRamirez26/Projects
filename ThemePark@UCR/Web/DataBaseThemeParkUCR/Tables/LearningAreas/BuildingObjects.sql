CREATE TABLE [ThemePark].[BuildingObjects] (
	ObjectId UNIQUEIDENTIFIER,
	CONSTRAINT PK_BuildingObjects PRIMARY KEY (ObjectId),
	ObjectType VARCHAR(127) NOT NULL,
	Plane VARCHAR(127) NOT NULL,
	ObjectName VARCHAR(127) NOT NULL,
	CONSTRAINT Object_base_is_Template
		FOREIGN KEY (ObjectName, Plane, ObjectType)
		REFERENCES ThemePark.[BOTemplates](ObjectName, Plane, ObjectType)
			ON DELETE NO ACTION
			ON UPDATE NO ACTION,
	[Length] FLOAT NOT NULL,
	Width FLOAT NOT NULL,
	Height FLOAT NOT NULL,
	ColorAmount TINYINT NOT NULL,
	Color1 CHAR(7) NOT NULL,
	Color2 CHAR(7) NULL,
	Color3 CHAR(7) NULL,
	CenterX FLOAT NOT NULL,
	CenterY FLOAT NOT NULL,
	Rotation FLOAT NOT NULL,
	LevelId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_BuildingObject_belongs_to_Level
		FOREIGN KEY (LevelId)
		REFERENCES ThemePark.[Level](LevelId)
			ON DELETE CASCADE
			ON UPDATE CASCADE,
	WallId TINYINT NULL
)
