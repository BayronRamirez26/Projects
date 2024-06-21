CREATE TABLE ThemePark.ExternalPerson (
	ExternalPersonId VARCHAR(255) PRIMARY KEY,
	FOREIGN KEY (ExternalPersonId)
		REFERENCES ThemePark.Person(PersonId)
)