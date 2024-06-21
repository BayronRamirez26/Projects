CREATE TABLE ThemePark.Researcher (
	ResearcherId VARCHAR(255) PRIMARY KEY,
	FOREIGN KEY (ResearcherId)
		REFERENCES ThemePark.Person(PersonId)
)