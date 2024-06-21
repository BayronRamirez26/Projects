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
Post-deployment script for ThemePark.Campus
*/
MERGE INTO ThemePark.Campus AS TARGET
USING (VALUES
    (/*CampusId*/       '430cd9b9-8acb-4e76-93bf-5e288b1cd242', 
    /*UniversityId*/    '8a3675d2-9bec-497a-b045-c0061dc8a48d', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede Rodrigo Facio'),

    (/*CampusId*/       '4617b561-4d73-4d27-9903-cf4410284161', 
    /*UniversityId*/    '8a3675d2-9bec-497a-b045-c0061dc8a48d', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede de Occidente'),

    (/*CampusId*/       '415b95a3-f70d-497a-9555-f8cd47d0bc36', 
    /*UniversityId*/    '8a3675d2-9bec-497a-b045-c0061dc8a48d', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede del Atlantico'),
    
    (/*CampusId*/       'c71d9464-0837-45ce-b86b-2a6a59dc43b0', 
    /*UniversityId*/    '8a3675d2-9bec-497a-b045-c0061dc8a48d', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede del Pacifico'),

    (/*CampusId*/       '2f15f49d-f269-4f8c-bb9f-d1d265b76158', 
    /*UniversityId*/    '8a3675d2-9bec-497a-b045-c0061dc8a48d', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede del Sur'),

    (/*CampusId*/       '49e7fbc2-ea93-47c5-81ee-e781fe06af85', 
    /*UniversityId*/    '8a3675d2-9bec-497a-b045-c0061dc8a48d', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede del Caribe'),

    (/*CampusId*/       'db8295bc-714d-4744-9e2f-61ba558b7a00', 
    /*UniversityId*/    '8a3675d2-9bec-497a-b045-c0061dc8a48d', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede de Guanacaste'),

    (/*CampusId*/       '41064d81-52bb-43c7-a90f-80b50e8fb822', 
    /*UniversityId*/    '8a3675d2-9bec-497a-b045-c0061dc8a48d', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede del Este'),

    (/*CampusId*/       'b78e81a5-6f67-4456-bce0-bd4aa486bf85', 
    /*UniversityId*/    '8a3675d2-9bec-497a-b045-c0061dc8a48d', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede Interuniversitaria de Alajuela')
)
AS SOURCE (
    CampusId,
    UniversityId,
    UniversityName,
    CampusName
)
ON
    TARGET.CampusId = SOURCE.CampusId
WHEN NOT MATCHED THEN
    INSERT (
        CampusId,
        UniversityId,
        UniversityName,
        CampusName
    )
    VALUES (
        SOURCE.CampusId,
        SOURCE.UniversityId,
        SOURCE.UniversityName,
        SOURCE.CampusName
    )
WHEN MATCHED THEN
    UPDATE SET
        UniversityId = SOURCE.UniversityId,
        UniversityName = SOURCE.UniversityName,
        CampusName = SOURCE.CampusName;
