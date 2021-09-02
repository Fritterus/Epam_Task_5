ALTER TABLE [dbo].[History]
ADD CONSTRAINT [FK_Book_History] FOREIGN KEY ([BookId]) 
	REFERENCES [dbo].[Book] ([Id])
