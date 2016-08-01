USE [DB_9D8937_WTJ]
GO

/****** Object:  Table [dbo].[Transaction]    Script Date: 7/19/2016 11:11:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transaction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HouseholdID] [int] NULL,
	[TransTypeID] [int] NULL,
	[TransIncrID] [int] NULL,
	[TransMethID] [int] NULL,
	[Date] [datetime] NOT NULL,
	[Amount] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([HouseholdID])
REFERENCES [dbo].[Households] ([ID])
GO

ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([TransTypeID])
REFERENCES [dbo].[TransactionType] ([ID])
GO

ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([TransIncrID])
REFERENCES [dbo].[TransactionIncrement] ([ID])
GO

ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([TransMethID])
REFERENCES [dbo].[TransactionMethod] ([ID])
GO

