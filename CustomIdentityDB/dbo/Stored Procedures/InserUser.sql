CREATE PROCEDURE dbo.InsertUser
	-- Add the parameters for the stored procedure here
	   @Username nvarchar(250)
      ,@Email nvarchar(250)
      ,@Password nvarchar(250)
      ,@Status int
      ,@Active bit
      ,@Deleted bit
      ,@EmailVerified bit
      ,@FisrtName nvarchar(250)
      ,@LastName nvarchar(250)
      ,@Phone nvarchar(250)
      ,@PhoneVerified bit
      ,@ProfilePic nvarchar(500)
      ,@SecurityStamp nvarchar(500) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Users]
           ([Username]
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
           ,[SecurityStamp])
     VALUES
           (
			  @Username 
			  ,@Email 
			  ,@Password 
			  ,@Status 
			  ,GETDATE()
			  ,@Active 
			  ,@Deleted 
			  ,@EmailVerified
			  ,@FisrtName
			  ,@LastName
			  ,@Phone 
			  ,@PhoneVerified 
			  ,@ProfilePic
			  ,@SecurityStamp 
			 )
	return @@IDENTITY	


END
