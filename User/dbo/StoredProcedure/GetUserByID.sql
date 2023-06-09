CREATE PROCEDURE [dbo].[GetUserByID]
	@id int

AS
BEGIN
	SELECT * from dbo.[User] where [UserId] = @id;
END