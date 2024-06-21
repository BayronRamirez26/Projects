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

MERGE INTO ThemePark.Role AS Target
USING (VALUES
	('8f2feedc-90e5-40ab-914e-ec331bcb3f30','Professor'),
	('4171c52a-0413-499b-b0e9-e6bcddb8d6fa','Admin'),
	('5ac445c2-ee01-4ca2-ba63-b230515d8e7b','Student'),
	('e18bfbd4-317f-4190-8121-e5da7bce689e','SubAdmin'),
	('61e49aa9-6476-444c-a616-05a002127b0a','SubProfessor')
)
AS SOURCE ([RoleId], [RoleName])
ON TARGET.[RoleId] = SOURCE.[RoleId]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([RoleId], [RoleName])
		VALUES (SOURCE.[RoleId], SOURCE.[RoleName])
WHEN MATCHED THEN
	UPDATE SET
		[RoleId] = SOURCE.[RoleId],
		[RoleName] = SOURCE.[RoleName];