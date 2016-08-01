USE [DB_9D8937_WTJ]
GO

/****** Object:  Table [dbo].[TransactionMethod]    Script Date: 7/19/2016 11:12:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TransactionMethod](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TransMethod] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

