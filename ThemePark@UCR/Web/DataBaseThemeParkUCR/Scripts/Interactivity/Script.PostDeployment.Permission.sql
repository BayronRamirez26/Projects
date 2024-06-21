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

MERGE INTO ThemePark.Permission AS Target
USING (VALUES
	('60b621bf-a23d-4e89-98ab-25771f88909f','Create'),
	('434f7bfc-947a-414c-85cf-6d4fe9e98a7f','Read'),
	('5ef25d03-e2c3-454b-b71f-bcfe0a271f5a','Update'),
	('e5187d01-874e-4c9b-bd55-74a204fbbea2','Delete'),
	('76cbf19a-efec-42eb-81fc-b267af35db56','GodLike')
)
AS SOURCE ([PermissionId], [PermissionDescription])
ON TARGET.[PermissionId] = SOURCE.[PermissionId]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([PermissionId], [PermissionDescription])
		VALUES (SOURCE.[PermissionId], SOURCE.[PermissionDescription])
WHEN MATCHED THEN
	UPDATE SET
		[PermissionId] = SOURCE.[PermissionId],
		[PermissionDescription] = SOURCE.[PermissionDescription];