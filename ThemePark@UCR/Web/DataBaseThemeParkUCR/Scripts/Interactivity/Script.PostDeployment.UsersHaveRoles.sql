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


MERGE INTO ThemePark.UsersHaveRoles AS Target
USING (VALUES
    ('20663e4f-eed6-4b6e-87cd-830a41d15e84','8f2feedc-90e5-40ab-914e-ec331bcb3f30',1),
    ('20663e4f-eed6-4b6e-87cd-830a41d15e84','61e49aa9-6476-444c-a616-05a002127b0a',0),
    ('20663e4f-eed6-4b6e-87cd-830a41d15e84','e18bfbd4-317f-4190-8121-e5da7bce689e',1),
    ('5af38093-9e5c-438a-8b7a-6c27e2be3ecc','4171c52a-0413-499b-b0e9-e6bcddb8d6fa',0),
    ('96f75b11-6081-44b5-ad14-443154262bbc','5ac445c2-ee01-4ca2-ba63-b230515d8e7b',1),
    ('a26c5068-4617-4172-9f33-dd74d4144eac','4171c52a-0413-499b-b0e9-e6bcddb8d6fa',1),
    ('1bcc9960-f9f9-4121-8037-09d1877f66eb','8f2feedc-90e5-40ab-914e-ec331bcb3f30',1)
) AS SOURCE ([UserId], [RoleId], [IsActive])
ON (TARGET.[UserId] = SOURCE.[UserId] AND TARGET.[RoleId] = SOURCE.[RoleId])
WHEN MATCHED THEN
    UPDATE SET
        [IsActive] = SOURCE.[IsActive]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([UserId], [RoleId], [IsActive])
    VALUES (SOURCE.[UserId], SOURCE.[RoleId], SOURCE.[IsActive]);
