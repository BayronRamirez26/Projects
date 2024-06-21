CREATE TABLE ThemePark.University (
    UniversityId UNIQUEIDENTIFIER,
    CONSTRAINT PK_University PRIMARY KEY (UniversityId),
    UniversityName VARCHAR(255) NOT NULL,
    CONSTRAINT University_is_Unique 
        UNIQUE (UniversityName)
)