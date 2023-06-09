CREATE PROCEDURE [dbo].[UpdateUserByID]
	@id int,
	@firstname nvarchar(50),
	@lastname nvarchar(50)
AS
BEGIN
	UPDATE dbo.[User]
	SET FirstName = @firstname, LastName = @lastname
	where [UserId] = @id;
END
