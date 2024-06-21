/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


MERGE INTO ThemePark.RolesHavePermissions AS Target
USING (VALUES
	('4171c52a-0413-499b-b0e9-e6bcddb8d6fa','60b621bf-a23d-4e89-98ab-25771f88909f'),
	('4171c52a-0413-499b-b0e9-e6bcddb8d6fa','434f7bfc-947a-414c-85cf-6d4fe9e98a7f'),
	('4171c52a-0413-499b-b0e9-e6bcddb8d6fa','5ef25d03-e2c3-454b-b71f-bcfe0a271f5a'),
	('4171c52a-0413-499b-b0e9-e6bcddb8d6fa','e5187d01-874e-4c9b-bd55-74a204fbbea2'),
	('5ac445c2-ee01-4ca2-ba63-b230515d8e7b','e5187d01-874e-4c9b-bd55-74a204fbbea2'),
	('8f2feedc-90e5-40ab-914e-ec331bcb3f30','434f7bfc-947a-414c-85cf-6d4fe9e98a7f')
)
AS SOURCE ([RoleId], [PermissionId])
ON TARGET.[RoleId] = SOURCE.[RoleId]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([RoleId], [PermissionId])
		VALUES (SOURCE.[RoleId], SOURCE.[PermissionId])
WHEN MATCHED THEN
	UPDATE SET
		[RoleId] = SOURCE.[RoleId],
		[PermissionId] = SOURCE.[PermissionId];