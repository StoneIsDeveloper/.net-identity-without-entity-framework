CREATE TABLE [dbo].[Roles](
	[Id] int,
	[Name] [nvarchar](50) NOT NULL,
	NormalizedName [nvarchar](200)  NULL,
	ConcurrencyStamp [nvarchar](200)  NULL,
	RoleDescription [nvarchar](500)  NULL

 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO