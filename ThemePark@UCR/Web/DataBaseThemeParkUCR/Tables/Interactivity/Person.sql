CREATE TABLE ThemePark.Person (
	PersonId VARCHAR(255) PRIMARY KEY,
	FirstName VARCHAR(64) NOT NULL,
	MiddleName VARCHAR(64),
	FirstLastName VARCHAR(64) NOT NULL,
	SecondLastName VARCHAR(64),
	BirthDate DATE,
	PhoneNumber VARCHAR(20),
	Email VARCHAR(320)
)