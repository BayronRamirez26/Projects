MERGE INTO ThemePark.Users AS Target
USING (VALUES
	('20663e4f-eed6-4b6e-87cd-830a41d15e84','nick1','pass' ),
	('5af38093-9e5c-438a-8b7a-6c27e2be3ecc','nick2','pass' ),
	('96f75b11-6081-44b5-ad14-443154262bbc','nick3','pass' )
)
AS SOURCE ([UserId], [UserNickName], [UserPasswordHash])
ON TARGET.[UserID] = SOURCE.[UserId]
AND [UserNickName] = SOURCE.[UserNickName]
AND [UserPasswordHash] = SOURCE.[UserPasswordHash]
WHEN NOT MATCHED BY TARGET THEN
		INSERT ([UserId], [UserNickName], [UserPasswordHash])
		VALUES (SOURCE.[UserId], SOURCE.[UserNickName])
WHEN MATCHED THEN
	UPDATE SET
		[UserId] = SOURCE.[UserId],
		[UserNickName] = SOURCE.[UserNickName],
		[UserPasswordHash] = SOURCE.[UserPasswordHash];