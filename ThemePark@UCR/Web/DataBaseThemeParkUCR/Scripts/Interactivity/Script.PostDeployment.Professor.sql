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

MERGE INTO ThemePark.Professor AS Target
USING (VALUES
    ('b7dfde8d-8eae-4f39-98e3-cc4f2b7c5f0d', 'dd2b4ae3-a90e-47c2-a786-14cd9dc8a21e', 'juan.cordero@ucr.ac.cr', 1),
    ('c8e0e4e9-3d5a-432d-a55e-6c5f1c0e7d1e', '728fb1e1-d741-4e0e-988b-5378c1c41e03', 'maria.ramirez@ucr.ac.cr', 1)
)
AS SOURCE ([ProfessorId], [PersonId], [InstitutionalEmail], [IsActive])
ON TARGET.[ProfessorId] = SOURCE.[ProfessorId]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([ProfessorId], [PersonId], [InstitutionalEmail], [IsActive])
    VALUES (SOURCE.[ProfessorId], SOURCE.[PersonId], SOURCE.[InstitutionalEmail], SOURCE.[IsActive])
WHEN MATCHED THEN
    UPDATE SET
        [PersonId] = SOURCE.[PersonId], 
        [InstitutionalEmail] = SOURCE.[InstitutionalEmail], 
        [IsActive] = SOURCE.[IsActive];