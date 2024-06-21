CREATE TABLE ThemePark.Building (
    BuildingId UNIQUEIDENTIFIER,
    CONSTRAINT PK_Building PRIMARY KEY (BuildingId),
    SiteId UNIQUEIDENTIFIER,
    /*CONSTRAINT FK_Building_belongs_to_Site
        FOREIGN KEY (SiteId)
        REFERENCES ThemePark.[Site](SiteId)
            ON DELETE CASCADE
            ON UPDATE CASCADE,*/
    UniversityName VARCHAR(255) NOT NULL,
    CampusName VARCHAR(255) NOT NULL,
    SiteName VARCHAR(127) NOT NULL,
    CONSTRAINT FK_Building_references_Names
        FOREIGN KEY (UniversityName, CampusName, SiteName)
        REFERENCES ThemePark.[Site](UniversityName, CampusName, SiteName)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    BuildingAcronym VARCHAR(10) NOT NULL,
    BuildingName VARCHAR(255) NOT NULL,
    CenterX FLOAT NOT NULL,
    CenterY FLOAT NOT NULL,
    Rotation FLOAT NOT NULL,
    [Length] FLOAT NOT NULL,
    Width FLOAT NOT NULL,
    Height FLOAT DEFAULT 1,
    WallsColor CHAR(7) DEFAULT '#FFFFFF',
    RoofColor CHAR(7) DEFAULT '#FFFFFF',
    LevelCount TINYINT DEFAULT 0
)