CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL IDENTITY(1,1) Primary key ,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName]  nvarchar(50) NOT NULL
)
