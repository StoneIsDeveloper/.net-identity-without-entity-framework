CREATE PROCEDURE [dbo].[spPerson_GetAllPerson]
     @LastName nvarchar(200)
AS
BEGIN
	select [PersonId],FirstName,LastName
	from dbo.Person
	where LastName = @LastName

END
