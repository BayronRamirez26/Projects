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
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO ThemePark.Person AS Target
USING (VALUES
    ('dd2b4ae3-a90e-47c2-a786-14cd9dc8a21e', 'Juan', 'Miguel', 'Cordero', 'González', '2000-05-15', '1234567890', 'juan.cordero@example.com'),
    ('728fb1e1-d741-4e0e-988b-5378c1c41e03', 'María', 'Isabel', 'Ramírez', 'Lopez', '1995-03-22', '0987654321', 'maria.ramirez@example.com'),
    ('029fafac-f87e-4acc-af59-b0cd33876b03', 'Carlos', 'Enrique', 'Sánchez', 'Mora', '1988-11-10', '2345678901', 'carlos.sanchez@example.com'),
    ('55568871-e5a5-48ab-8e64-219deef2513c', 'Ana', 'María', 'Fernández', 'Ruiz', '1992-07-30', '3456789012', 'ana.fernandez@example.com'),
    ('9ec546db-623a-4041-9032-b898a26fa718', 'José', 'Luis', 'Martínez', 'García', '1985-02-14', '4567890123', 'jose.martinez@example.com'),
    ('da7ca981-bf73-4632-a6d9-f440bb908ae5', 'Laura', 'Beatriz', 'Gómez', 'Torres', '1990-12-05', '5678901234', 'laura.gomez@example.com'),
    ('334e2d24-1dbc-43b0-9836-1c05d6cc79b0', 'AdminName', 'AdminName', 'AdminLastName', 'AdminLastName2', '1990-12-05', '5678901234', 'esteban.rojascarranza@ucr.ac.cr'),
    ('5382a6c1-bd63-40c8-b893-631dca4eaeb9', 'ProfeName', 'ProfeName', 'ProfeLastName', 'ProfeLastName2', '1990-12-06', '5678901233', 'esteban.rojascarranza@ucr.ac.cr')
)
AS SOURCE ([PersonId], [FirstName], [MiddleName], [FirstLastName], [SecondLastName], [BirthDate], [PhoneNumber], [Email])
ON TARGET.[PersonId] = SOURCE.[PersonId]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([PersonId], [FirstName], [MiddleName], [FirstLastName], [SecondLastName], [BirthDate], [PhoneNumber], [Email])
    VALUES (SOURCE.[PersonId], SOURCE.[FirstName], SOURCE.[MiddleName], SOURCE.[FirstLastName], SOURCE.[SecondLastName], SOURCE.[BirthDate], SOURCE.[PhoneNumber], SOURCE.[Email])
WHEN MATCHED THEN
    UPDATE SET
        [PersonId] = SOURCE.[PersonId], 
        [FirstName] = SOURCE.[FirstName], 
        [MiddleName] = SOURCE.[MiddleName], 
        [FirstLastName] = SOURCE.[FirstLastName], 
        [SecondLastName] = SOURCE.[SecondLastName], 
        [BirthDate] = SOURCE.[BirthDate],
        [PhoneNumber] = SOURCE.[PhoneNumber], 
        [Email] = SOURCE.[Email];
