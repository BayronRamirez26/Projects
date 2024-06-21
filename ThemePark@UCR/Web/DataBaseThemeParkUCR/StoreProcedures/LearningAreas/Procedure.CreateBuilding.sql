CREATE PROCEDURE [CreateBuilding]
	@BuildingId UNIQUEIDENTIFIER,
	@UniversityName VARCHAR(255),
	@CampusName VARCHAR(255),
	@SiteName VARCHAR(127),
	@BuildingAcronym VARCHAR(10),
	@BuildingName VARCHAR(255),
    @CenterX FLOAT,
    @CenterY FLOAT,
	@Length FLOAT,
    @Width FLOAT,
    @Rotation FLOAT,
	@WallsColor CHAR(7),
    @RoofColor CHAR(7),
	@Height FLOAT,
	@LevelCount TINYINT
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY

		SET @LevelCount = 0
		SET @Height = 3

		INSERT INTO [ThemePark].[Building] (
			[BuildingId],
			[UniversityName],
			[CampusName],
			[SiteName],
			[BuildingAcronym],
			[BuildingName],
			[CenterX],
			[CenterY],
			[Rotation],
			[Length],
			[Width],
			[Height],
			[WallsColor],
			[RoofColor],
			[LevelCount])
		VALUES (
			@BuildingId,
			@UniversityName,
			@CampusName,
			@SiteName,
			@BuildingAcronym,
			@BuildingName,
			@CenterX,
			@CenterY,
			@Rotation,
			@Length,
			@Width,
			@Height,
			@WallsColor,
			@RoofColor,
			@LevelCount)

        COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION
		END
	END CATCH
END
