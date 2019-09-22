CREATE PROCEDURE dbo.GetUserByID
  @ID INT
AS
BEGIN
   SELECT [Id]
      ,[Username]
      ,[Email]
      ,[Password]
      ,[Status]
      ,[CreatedOnDate]
      ,[Active]
      ,[Deleted]
      ,[EmailVerified]
      ,[FisrtName]
      ,[LastName]
      ,[Phone]
      ,[PhoneVerified]
      ,[ProfilePic]
      ,[SecurityStamp]

   FROM dbo.Users
   WHERE Id = @ID

END
