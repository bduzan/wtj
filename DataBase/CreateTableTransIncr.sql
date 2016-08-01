USE [DB_9D8937_WTJ]
GO

/****** Object:  Table [dbo].[TransactionIncrement]    Script Date: 7/19/2016 11:11:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TransactionIncrement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TransIncr] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

