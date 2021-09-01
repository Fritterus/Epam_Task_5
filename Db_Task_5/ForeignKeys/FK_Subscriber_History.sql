ALTER TABLE [dbo].[History]
ADD CONSTRAINT [FK_Subscriber_History] FOREIGN KEY ([SubscriberId]) 
	REFERENCES [dbo].[Subscriber] ([Id])
