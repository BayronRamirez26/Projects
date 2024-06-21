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

/*
Post-deployment script for ThemePark.University
*/
MERGE INTO ThemePark.University AS TARGET
USING (VALUES
    (/*UniversityId*/   '8a3675d2-9bec-497a-b045-c0061dc8a48d', 
    /*UniversityName*/  'Universidad de Costa Rica')
)
AS SOURCE (
    UniversityId, 
    UniversityName
)
ON
    TARGET.UniversityId = SOURCE.UniversityId
WHEN NOT MATCHED THEN
    INSERT (
        UniversityId, 
        UniversityName
    )
    VALUES (
        SOURCE.UniversityId, 
        SOURCE.UniversityName
    )
WHEN MATCHED THEN
    UPDATE SET
        UniversityName = SOURCE.UniversityName;
