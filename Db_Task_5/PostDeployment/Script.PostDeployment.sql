INSERT [dbo].[Author] ([Name], [Surname], [Patronymic])
VALUES (N'Lev', N'Tolstoy', N'Nikolayevich'),
	   (N'Dina', N'Rubina', N'Ilyinichna'),
	   (N'Holly', N'Vebb', null),
	   (N'Marina', N'Abramova', null),
	   (N'Anjey', N'Sapkovskiy', null)

INSERT [dbo].[Genre] ([Name])
VALUES (N'Novel'),
	   (N'Drama'),
	   (N'Fantasy'),
	   (N'Story'),
	   (N'Comedy'),
	   (N'Tragedy')

INSERT [dbo].[Book] ([Name], [AuthorId], [GenreId])
VALUES (N'War and Piece', 1, 2),
	   (N'Phone wife', 2, 3),
	   (N'Unicorn mystery', 3, 1),
	   (N'The wither', 5, 3),
	   (N'Im a bat', 4, 4),
	   (N'Elf blood', 5, 6)

INSERT [dbo].[Subscriber] ([FullName], [Gender], [BirthYear])
VALUES (N'Kardash Egor Vyacheslavovich', N'Male', CAST(N'2000-11-17' AS Date)),
	   (N'Gatalskiy Renat Alexandrovich', N'Male', CAST(N'1999-06-26' AS Date)),
	   (N'Belaichuk Anna Nikolaevna', N'Female', CAST(N'2001-05-08' AS Date)),
	   (N'Goncharuk Artem Gennadievich', N'Male', CAST(N'2000-07-13' AS Date)),
	   (N'Kolocey Olga Valerievna', N'Female', CAST(N'1998-10-01' AS Date))

INSERT [dbo].[History] ([ReceivingDate], [BookId], [SubscriberId], [IsReturn], [BookCondition])
VALUES (CAST(N'2021-04-04' AS Date), 2, 2, 1, N'New'),
	   (CAST(N'2021-04-07' AS Date), 1, 4, 0, null),
	   (CAST(N'2021-04-13' AS Date), 2, 4, 0, N'New'),
	   (CAST(N'2021-05-17' AS Date), 4, 3, 1, N'Shabby'),
	   (CAST(N'2021-05-21' AS Date), 3, 5, 0, N'Shabby'),
	   (CAST(N'2021-05-27' AS Date), 2, 5, 0, null),
	   (CAST(N'2021-05-30' AS Date), 5, 3, 0, null),
	   (CAST(N'2021-06-03' AS Date), 5, 4, 0, null),
	   (CAST(N'2021-06-09' AS Date), 5, 4, 0, null),
	   (CAST(N'2021-06-11' AS Date), 5, 1, 0, N'Shabby')