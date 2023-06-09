/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (SELECT 1 from dbo.[User])
BEGIN
  INSERT INTO dbo.[User] (FirstName, LastName)
  values ('Jane','Hamilton'),
  ('Jill','Mckinsey'),
  ('John','Doe');
END

if not exists (Select 1 from dbo.[Book])
BEGIN
  INSERT INTO dbo.[Book] (Book_Name)
  values('Lord of the Rings'),
  ('Kafka on the shore'),
  ('Pride and Prejudice')
END

if not exists (Select 1 from dbo.[Downloads])
BEGIN
 INSERT INTO dbo.[Downloads](UserID,BookID,Download_Date)
 values (1,1,'2022-05-08 12:35:29.123'),
 (1,2,'2022-06-20 09:10:35.123'),
 (2,3,'2022-04-11 15:15:29.123'),
 (3,2,'2022-03-28 18:07:29.123')
END

