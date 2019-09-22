alter PROCEDURE dbo.GetUserByUserName
  @UserName nvarchar(250)
AS
BEGIN
   SET NOCOUNT ON;

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
   WHERE Username = @UserName

END