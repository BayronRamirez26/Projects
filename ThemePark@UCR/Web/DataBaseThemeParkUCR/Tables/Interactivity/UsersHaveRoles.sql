CREATE TABLE ThemePark.UsersHaveRoles (
	UserId VARCHAR(255),
	FOREIGN KEY (UserId)
		REFERENCES ThemePark.[Users](UserId) ON DELETE CASCADE,
	RoleId VARCHAR(255),
	IsActive bit NOT NULL,
	FOREIGN KEY (RoleId)
		REFERENCES ThemePark.[Role](RoleId) ON DELETE CASCADE,
	PRIMARY KEY (UserId, RoleId)
)