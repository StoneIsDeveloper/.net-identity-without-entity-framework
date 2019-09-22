CREATE PROCEDURE dbo.GetUserByEmail
  @Email nvarchar(250)
AS
BEGIN
   SELECT top 1 [Id]
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
   WHERE Email = @Email

END