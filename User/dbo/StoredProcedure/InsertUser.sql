CREATE PROCEDURE [dbo].[InsertUser]
   @firstname nvarchar(50),
   @lastname nvarchar(50)
AS
BEGIN
INSERT INTO dbo.[User] (FirstName, LastName)
VALUES(@firstname,@lastname);
END
