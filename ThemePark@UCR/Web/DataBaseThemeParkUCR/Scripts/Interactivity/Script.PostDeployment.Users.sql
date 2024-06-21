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

MERGE INTO ThemePark.Users AS Target
USING (VALUES
	('20663e4f-eed6-4b6e-87cd-830a41d15e84','ShirleyCruz','Admin12*',1 ,'dd2b4ae3-a90e-47c2-a786-14cd9dc8a21e'),
	('5af38093-9e5c-438a-8b7a-6c27e2be3ecc','WilmerLopez','Admin11*',0 ,'728fb1e1-d741-4e0e-988b-5378c1c41e03'),
	('96f75b11-6081-44b5-ad14-443154262bbc','PateCenteno','Admin10*',1 ,'029fafac-f87e-4acc-af59-b0cd33876b03'),
	('a26c5068-4617-4172-9f33-dd74d4144eac','AdminUser','dummyPasswordHash*',1 ,'334e2d24-1dbc-43b0-9836-1c05d6cc79b0'),
	('1bcc9960-f9f9-4121-8037-09d1877f66eb','ProfeUser','dummyPasswordHash*',1 ,'5382a6c1-bd63-40c8-b893-631dca4eaeb9')
)
AS SOURCE ([UserId], [UserNickName], [UserPasswordHash], [IsActive], [PersonId])
ON TARGET.[UserId] = SOURCE.[UserId]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UserId], [UserNickName], [UserPasswordHash], [IsActive], [PersonId])
		VALUES (SOURCE.[UserId], SOURCE.[UserNickName], SOURCE.[UserPasswordHash], SOURCE.[IsActive], SOURCE.[PersonId])
WHEN MATCHED THEN
	UPDATE SET
		[UserId] = SOURCE.[UserId],
		[UserNickName] = SOURCE.[UserNickName],
		[UserPasswordHash] = SOURCE.[UserPasswordHash],
		[IsActive] = SOURCE.[IsActive],
		[PersonId] = SOURCE.[PersonId];