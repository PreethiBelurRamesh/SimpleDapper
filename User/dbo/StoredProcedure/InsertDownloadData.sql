CREATE PROCEDURE [dbo].[InsertDownloadData]
	@download_date datetime,
	@userid int,
	@bookid int
AS
Begin
    If exists(SELECT * FROM dbo.[User] where UserId = @userid ) 
	BEGIN
	if exists(SELECT * FROM dbo.[Book] where Book_Id = @bookid)
	Begin
	Insert into dbo.[Downloads] (Download_Date,UserID,BookID)
	values(@download_date,@userid,@bookid)
	end
	END
end
