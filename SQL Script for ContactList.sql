USE [master]
GO

/****** Object:  Table [dbo].[Contact]    Script Date: 12/12/2018 2:05:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](25) NOT NULL,
	[LastName] [varchar](25) NULL,
	[Address] [varchar](25) NULL,
	[City] [varchar](10) NULL,
	[State] [varchar](5) NOT NULL,
	[Zip] [varchar](10) NULL,
	[Country] [varchar](10) NULL,
	[HomePhone] [varchar](25) NULL,
	[MobilePhone] [varchar](25) NULL,
	[WorkPhone] [varchar](25) NULL,
	[Fax] [varchar](25) NULL,
	[Email] [varchar](25) NULL,
	[Website] [varchar](25) NULL,
	[Facebook] [varchar](25) NULL,
	[Twitter] [varchar](25) NULL,
	[Instagram] [varchar](25) NULL
) ON [PRIMARY]
GO

USE [master]
GO


CREATE CLUSTERED INDEX [idx_Contact_Id] ON [dbo].[Contact]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO



