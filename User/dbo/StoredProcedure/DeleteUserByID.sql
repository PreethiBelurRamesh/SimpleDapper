CREATE PROCEDURE [dbo].[DeleteUserByID]
	@id int 
AS
BEGIN
	DELETE 
	FROM dbo.[User]
	where [UserId] = @id;
END
