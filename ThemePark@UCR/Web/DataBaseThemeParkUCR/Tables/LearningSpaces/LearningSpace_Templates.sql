CREATE TABLE [ThemePark].[LearningSpace_Templates]
(
	[Id]				UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[TemplateName]		VARCHAR (127)	 NULL,
	[SizeX]             FLOAT (53)       NOT NULL,
    [SizeY]             FLOAT (53)       NOT NULL,
    [SizeZ]             FLOAT (53)       NOT NULL,
	[FloorColor]        VARCHAR (127)    NULL,
    [CeilingColor]      VARCHAR (127)    NULL,
    [WallsColor]        VARCHAR (127)    NULL,
	[Type]                UNIQUEIDENTIFIER    NULL,
	FOREIGN KEY ([Type])
        REFERENCES ThemePark.[LearningSpaceType]([Id]),
)
