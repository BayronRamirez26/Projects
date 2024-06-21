-- Building Object Templates
CREATE TABLE [ThemePark].[BOTemplates] (
	TemplateId UNIQUEIDENTIFIER,
	CONSTRAINT PK_BOTemplates PRIMARY KEY (TemplateId),
	-- The ObjectType must be either 'Interactivo' or 'Decorativo'
	ObjectType VARCHAR(127) NOT NULL,
	CONSTRAINT ObjectType_is_Valid CHECK (ObjectType IN ('Interactivo', 'Decorativo')),
	Plane VARCHAR(127) NOT NULL,
	CONSTRAINT Plane_is_Valid CHECK (Plane IN ('Piso', 'Pared', 'Techo')),
	ObjectName VARCHAR(127) NOT NULL,
	-- The combination of ObjectName, ObjectType, and Plane must be unique
	CONSTRAINT Template_is_Unique UNIQUE (ObjectName, Plane, ObjectType),
	-- The plane must be 'Piso', 'Pared' or 'Techo'
	DefaultLength FLOAT NOT NULL,
	DefaultWidth FLOAT NOT NULL,
	DefaultHeight FLOAT NOT NULL,
	-- The object must have between 1 and 3 colors
	ColorAmount TINYINT NOT NULL,
	CONSTRAINT ColorAmount_is_Valid CHECK (ColorAmount BETWEEN 1 AND 3),
	Color1Name VARCHAR(127) NOT NULL,
	DefaultColor1 CHAR(7) NOT NULL,
	Color2Name VARCHAR(127) NULL,
	DefaultColor2 CHAR(7) NULL,
	Color3Name VARCHAR(127) NULL,
	DefaultColor3 CHAR(7) NULL
)
