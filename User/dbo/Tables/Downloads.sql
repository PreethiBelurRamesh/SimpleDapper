CREATE TABLE [dbo].[Downloads]
(
	[Download_Id] INT NOT NULL Identity(1,1) Primary key,
	[Download_Date] DateTime Not Null,
	[UserID] INT NOT NULL,
	[BookID] INT NOT NULL,
	CONSTRAINT "FK_User_Downloads" FOREIGN KEY 
	(
		"UserID"
	) REFERENCES "dbo"."User" (
		"UserId"
	),
		CONSTRAINT "FK_Book_Downloads" FOREIGN KEY 
	(
		"BookID"
	) REFERENCES "dbo"."Book" (
		"Book_Id"
	)
)
