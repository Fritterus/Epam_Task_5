ALTER TABLE [dbo].[Book]
ADD CONSTRAINT [FK_Author_Book] FOREIGN KEY ([AuthorId]) 
	REFERENCES [dbo].[Author] ([Id])
