CREATE TABLE ThemePark.Useristrator (
	UseristratorId VARCHAR(255) PRIMARY KEY,
	FOREIGN KEY (UseristratorId)
		REFERENCES ThemePark.Person(PersonId)
)