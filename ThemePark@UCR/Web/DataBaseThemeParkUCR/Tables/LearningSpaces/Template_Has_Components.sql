CREATE TABLE [ThemePark].[Template_Has_Components]
(
	[Id]				UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Component_type]	VARCHAR(20) NOT NULL,
	[Template]			UNIQUEIDENTIFIER NOT NULL,
	[SizeX]				FLOAT NULL,
	[SizeY]				FLOAT NULL,
	[PositionX]			FLOAT NULL,
	[PositionY]			FLOAT NULL,
	[PositionZ]			FLOAT NULL,
	[RotationX]			FLOAT NULL,
	[RotationY]			FLOAT NULL,
	FOREIGN KEY ([Template]) 
		REFERENCES ThemePark.[LearningSpace_Templates]([Id])
			ON DELETE CASCADE

)
