CREATE TABLE ThemePark.Campus (
    CampusId UNIQUEIDENTIFIER,
    CONSTRAINT PK_Campus PRIMARY KEY (CampusId),
    UniversityId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_Campus_belongs_to_University 
        FOREIGN KEY (UniversityId) 
        REFERENCES ThemePark.University(UniversityId)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    UniversityName VARCHAR(255) NOT NULL,
    CONSTRAINT FK_Campus_references_Names
        FOREIGN KEY (UniversityName)
        REFERENCES ThemePark.University(UniversityName)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,
    CampusName VARCHAR(255) NOT NULL,
    CONSTRAINT Campus_is_Unique 
        UNIQUE (UniversityName, CampusName)
)