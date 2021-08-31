INSERT [dbo].[Author] ([Id], [Name], [Surname], [Patronymic])
VALUES (1, N'Lev', N'Tolstoy', N'Nikolayevich'),
	   (2, N'Dina', N'Rubina', N'Ilyinichna'),
	   (3, N'Holly', N'Vebb', null),
	   (4, N'Marina', N'Abramova', null),
	   (5, N'Anjey', N'Sapkovskiy', null)

INSERT [dbo].[Book] ([Id], [Name], [AuthorId], [GenreId])
VALUES (1, N'War and Piece', 1, 2),
	   (2, N'Phone wife', 2, 3),
	   (3, N'Unicorn mystery', 3, 1),
	   (4, N'The wither', 5, 3),
	   (5, N'Im a bat', 4, 4),
	   (6, N'Elf blood', 5, 6)

INSERT [dbo].[Genre] ([Id], [Name])
VALUES (1, N'Novel'),
	   (2, N'Drama'),
	   (3, N'Fantasy'),
	   (4, N'Story'),
	   (5, N'Comedy'),
	   (6, N'Tragedy')

INSERT [dbo].[Subscriber] ([Id], [FullName], [Gender], [BirthYear])
VALUES (1, N'Kardash Egor Vyacheslavovich', N'Male', CAST(N'2000-11-17' AS Date)),
	   (2, N'Gatalskiy Renat Alexandrovich', N'Male', CAST(N'1999-06-26' AS Date)),
	   (3, N'Belaichuk Anna Nikolaevna', N'Female', CAST(N'2001-05-08' AS Date)),
	   (4, N'Goncharuk Artem Gennadievich', N'Male', CAST(N'2000-07-13' AS Date)),
	   (5, N'Kolocey Olga Valerievna', N'Female', CAST(N'1998-10-01' AS Date))

INSERT [dbo].[History] ([Id], [ReceivingDate], [SubscriberId], [IsReturn], [BookCondition])
VALUES (1, CAST(N'2021-04-04' AS Date), 2, 1, N'New'),
	   (2, CAST(N'2021-04-07' AS Date), 4, 0, null),
	   (3, CAST(N'2021-04-13' AS Date), 4, 0, null),
	   (4, CAST(N'2021-05-17' AS Date), 3, 1, N'Shabby'),
	   (5, CAST(N'2021-05-21' AS Date), 5, 0, null),
	   (6, CAST(N'2021-05-27' AS Date), 5, 0, null),
	   (7, CAST(N'2021-05-30' AS Date), 3, 0, null),
	   (8, CAST(N'2021-06-03' AS Date), 4, 0, null),
	   (9, CAST(N'2021-06-09' AS Date), 4, 0, null),
	   (10, CAST(N'2021-06-11' AS Date), 1, 0, N'Shabby')