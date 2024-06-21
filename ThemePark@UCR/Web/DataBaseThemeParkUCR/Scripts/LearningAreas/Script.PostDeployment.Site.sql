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
Post-deployment script for ThemePark.[Site]
*/
MERGE INTO ThemePark.[Site] AS TARGET
USING (VALUES
    (/*SiteId*/         'd38bf38e-93f5-4452-9bd8-a78ffd4e16a5', 
    /*CampusId*/        '430cd9b9-8acb-4e76-93bf-5e288b1cd242', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede Rodrigo Facio', 
    /*SiteName*/        'Finca 1', 
    /*SizeX*/           700.0, 
    /*SizeY*/           700.0),

    (/*SiteId*/         '86815ee2-c5c0-43ca-bdbc-240e7e939c1e', 
    /*CampusId*/        '430cd9b9-8acb-4e76-93bf-5e288b1cd242', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede Rodrigo Facio', 
    /*SiteName*/        'Finca 2', 
    /*SizeX*/           1000.0, 
    /*SizeY*/           1000.0),

    (/*SiteId*/         'f4887842-cc5d-4f45-9f98-b863398eacdf', 
    /*CampusId*/        '430cd9b9-8acb-4e76-93bf-5e288b1cd242', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede Rodrigo Facio', 
    /*SiteName*/        'Deportivas', 
    /*SizeX*/           600.0, 
    /*SizeY*/           600.0),

    (/*SiteId*/         'a940b8bc-febe-44bb-9f16-d1822f901028', 
    /*CampusId*/        '4617b561-4d73-4d27-9903-cf4410284161', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede de Occidente', 
    /*SiteName*/        'Finca 1', 
    /*SizeX*/           500.0, 
    /*SizeY*/           500.0),

    (/*SiteId*/         '593e53e3-e60a-4666-8737-0c11d8dc402b', 
    /*CampusId*/        '415b95a3-f70d-497a-9555-f8cd47d0bc36', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede del Atlantico', 
    /*SiteName*/        'Finca 1', 
    /*SizeX*/           500.0, 
    /*SizeY*/           500.0),

    (/*SiteId*/         'cb5da788-5ac3-44dc-9125-3b15abbc2ee5', 
    /*CampusId*/        'c71d9464-0837-45ce-b86b-2a6a59dc43b0', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede del Pacifico', 
    /*SiteName*/        'Finca 1', 
    /*SizeX*/           500.0, 
    /*SizeY*/           500.0),

    (/*SiteId*/         '0982dc91-7392-492b-8c23-a0a45b8a6428', 
    /*CampusId*/        '2f15f49d-f269-4f8c-bb9f-d1d265b76158', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede del Sur', 
    /*SiteName*/        'Finca 1', 
    /*SizeX*/           500.0, 
    /*SizeY*/           500.0),

    (/*SiteId*/         '2dcb1f25-25c1-4b4f-a382-c8eae72f1639', 
    /*CampusId*/        '49e7fbc2-ea93-47c5-81ee-e781fe06af85', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede del Caribe', 
    /*SiteName*/        'Finca 1', 
    /*SizeX*/           500.0, 
    /*SizeY*/           500.0),

    (/*SiteId*/         '4ac4839f-a010-4a99-b645-ce37df0b7354', 
    /*CampusId*/        'db8295bc-714d-4744-9e2f-61ba558b7a00', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede de Guanacaste', 
    /*SiteName*/        'Finca 1', 
    /*SizeX*/           500.0, 
    /*SizeY*/           500.0),

    (/*SiteId*/         'abb6c112-198a-40bf-b8fb-a326b455bf55', 
    /*CampusId*/        '41064d81-52bb-43c7-a90f-80b50e8fb822', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede del Este', 
    /*SiteName*/        'Finca 1', 
    /*SizeX*/           500.0, 
    /*SizeY*/           500.0),

    (/*SiteId*/         '770e5f4c-e331-4e94-98f7-43a4e66d9e22', 
    /*CampusId*/        'b78e81a5-6f67-4456-bce0-bd4aa486bf85', 
    /*UniversityName*/  'Universidad de Costa Rica', 
    /*CampusName*/      'Sede Interuniversitaria de Alajuela', 
    /*SiteName*/        'Finca 1', 
    /*SizeX*/           500.0, 
    /*SizeY*/           500.0)
)
AS SOURCE (
    SiteId,
    CampusId,
    UniversityName,
    CampusName,
    SiteName,
    SizeX,
    SizeY
)
ON
    TARGET.SiteId = SOURCE.SiteId
WHEN NOT MATCHED THEN
    INSERT (
        SiteId,
        CampusId,
        UniversityName,
        CampusName,
        SiteName,
        SizeX,
        SizeY
    )
    VALUES (
        SOURCE.SiteId,
        SOURCE.CampusId,
        SOURCE.UniversityName,
        SOURCE.CampusName,
        SOURCE.SiteName,
        SOURCE.SizeX,
        SOURCE.SizeY
    )
WHEN MATCHED THEN
    UPDATE SET
        CampusId = SOURCE.CampusId,
        UniversityName = SOURCE.UniversityName,
        CampusName = SOURCE.CampusName,
        SiteName = SOURCE.SiteName,
        SizeX = SOURCE.SizeX,
        SizeY = SOURCE.SizeY;
