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

MERGE INTO ThemePark.Student AS Target
USING (VALUES
    ('d4df3f4d-8eae-4f39-98e3-cc4f2b7c5f0d', '029fafac-f87e-4acc-af59-b0cd33876b03', 'B81234', 1),
    ('e5e0f5f1-3d5a-432d-a55e-6c5f1c0e7d1e', '55568871-e5a5-48ab-8e64-219deef2513c', 'C01234', 1)
)
AS SOURCE ([StudentId], [PersonId], [StudentCard], [IsActive])
ON TARGET.[StudentId] = SOURCE.[StudentId]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([StudentId], [PersonId], [StudentCard], [IsActive])
    VALUES (SOURCE.[StudentId], SOURCE.[PersonId], SOURCE.[StudentCard], SOURCE.[IsActive])
WHEN MATCHED THEN
    UPDATE SET
        [PersonId] = SOURCE.[PersonId], 
        [StudentCard] = SOURCE.[StudentCard], 
        [IsActive] = SOURCE.[IsActive];