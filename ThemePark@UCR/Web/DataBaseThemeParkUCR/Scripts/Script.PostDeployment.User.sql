﻿/*
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
MERGE INTO ThemePark.[Users] AS Target
USING (VALUES
	('5f73d733-a4bd-4631-ae1a-f48113730ea4','nick1','password', 0 ),
	('5b18182d-f99d-4cd5-b67d-c3af88a2702d','nick2','password', 1 ),
	('cf498717-c5ce-4933-bfd4-3cec5b6a5ba6','nick3','password', 0)
)
AS SOURCE ([UserId], [UserNickName], [UserPasswordHash], [IsActive])
ON TARGET.[UserID] = SOURCE.[UserId]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UserId], [UserNickName], [UserPasswordHash], [IsActive])
		VALUES (SOURCE.[UserId], SOURCE.[UserNickName], SOURCE.[UserPasswordHash], SOURCE.[IsActive])
WHEN MATCHED THEN
	UPDATE SET
		[UserId] = SOURCE.[UserId],
		[UserNickName] = SOURCE.[UserNickName],
		[UserPasswordHash] = SOURCE.[UserPasswordHash],
		[IsActive] = SOURCE.[IsActive];