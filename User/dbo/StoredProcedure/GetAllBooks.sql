CREATE PROCEDURE [dbo].[GetAllBooks]
AS
BEGIN
	SELECT b.Book_Id, b.Book_Name FROM dbo.Book b
END
