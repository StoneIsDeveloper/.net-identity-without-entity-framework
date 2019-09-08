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

IF NOT EXISTS (SELECT * FROM dbo.Person where FirstName = 'Demo' and LastName = 'User' )
BEGIN
	INSERT INTO dbo.Person (FirstName,LastName)
	VALUES ('Demo','User')

END

GO
PRINT N'Update identityInit.';
  :r .\identityInit.sql
GO