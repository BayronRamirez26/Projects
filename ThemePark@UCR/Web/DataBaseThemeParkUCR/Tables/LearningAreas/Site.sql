CREATE TABLE ThemePark.[Site] (
    SiteId UNIQUEIDENTIFIER,
    CONSTRAINT PK_Site PRIMARY KEY (SiteId),
    CampusId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_Site_belongs_to_Campus
        FOREIGN KEY (CampusId)
        REFERENCES ThemePark.Campus(CampusId)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    UniversityName VARCHAR(255) NOT NULL,
    CampusName VARCHAR(255) NOT NULL,
    CONSTRAINT FK_Site_references_Names
        FOREIGN KEY (UniversityName, CampusName)
        REFERENCES ThemePark.Campus(UniversityName, CampusName)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,
    SiteName VARCHAR(127) NOT NULL,
    CONSTRAINT Site_is_Unique
        UNIQUE (UniversityName, CampusName, SiteName),
    SizeX FLOAT NOT NULL,
    SizeY FLOAT NOT NULL
)