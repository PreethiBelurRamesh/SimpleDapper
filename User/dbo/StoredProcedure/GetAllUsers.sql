CREATE PROCEDURE [dbo].[GetAllUsers]
	AS
BEGIN
	SELECT u.[UserId],u.FirstName,u.LastName from dbo.[User] u;
END
