CREATE TABLE [dbo].[History]
(
	[Id] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	[ReceivingDate] DATE NOT NULL,
	[BookId] INT NOT NULL,
	[SubscriberId] INT NOT NULL,
	[IsReturn] BIT NOT NULL,
	[BookCondition] NVARCHAR(128)
)
