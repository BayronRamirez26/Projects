CREATE TABLE ThemePark.[Level] (
    LevelId UNIQUEIDENTIFIER,
    CONSTRAINT PK_Level PRIMARY KEY (LevelId),
    BuildingId UNIQUEIDENTIFIER,
    CONSTRAINT FK_Level_belongs_to_Building
        FOREIGN KEY (BuildingId)
        REFERENCES ThemePark.Building(BuildingId)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    UniversityName VARCHAR(255) NOT NULL,
    CampusName VARCHAR(255) NOT NULL,
    SiteName VARCHAR(127) NOT NULL,
    BuildingAcronym VARCHAR(10) NOT NULL,
    LevelNumber TINYINT NOT NULL,
    SizeX FLOAT NOT NULL,
    SizeY FLOAT NOT NULL,
    SizeZ FLOAT NOT NULL,
    WallsColor CHAR(7) DEFAULT '#FFFFFF',
    FloorColor CHAR(7) DEFAULT '#FFFFFF',
    CeilingColor CHAR(7) DEFAULT '#FFFFFF',
    LearningSpaceCount TINYINT
)