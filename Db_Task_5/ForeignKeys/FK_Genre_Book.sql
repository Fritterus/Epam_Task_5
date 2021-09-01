ALTER TABLE [dbo].[Book]
ADD CONSTRAINT [FK_Genre_Book] FOREIGN KEY ([GenreId]) 
	REFERENCES [dbo].[Genre] ([Id])
