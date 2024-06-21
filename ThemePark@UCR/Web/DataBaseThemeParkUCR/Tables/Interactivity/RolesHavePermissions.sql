CREATE TABLE ThemePark.RolesHavePermissions (
	RoleId VARCHAR(255),
	FOREIGN KEY (RoleId)
		REFERENCES ThemePark.[Role](RoleId) ON DELETE CASCADE,
	PermissionId VARCHAR(255),
	FOREIGN KEY (PermissionId)
		REFERENCES ThemePark.Permission(PermissionId),
	PRIMARY KEY (RoleId, PermissionId)
)