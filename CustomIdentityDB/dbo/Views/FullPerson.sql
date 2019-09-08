CREATE VIEW [dbo].[FullPerson]
	AS 
	SELECT [PersonId],FirstName,LastName	
	FROM dbo.Person
	WHERE PersonId > 0
