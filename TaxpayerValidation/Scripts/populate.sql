USE [FluentValidation1]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 4/10/2024 1:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[EmailAddress] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Taxpayer]    Script Date: 4/10/2024 1:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Taxpayer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[SSN] [nvarchar](max) NULL,
	[PIN] [nchar](4) NULL,
	[StartDate] [date] NULL,
 CONSTRAINT [PK_Taxpayer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [EmailAddress]) VALUES (1, N'Karen', N'Payne', N'payne@comcast.net')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [EmailAddress]) VALUES (2, N'Bob', N'Smith', N'BillyBob@bear.com')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [EmailAddress]) VALUES (3, N'Jim', N'Jones', N'jj@gmailcom')
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET IDENTITY_INSERT [dbo].[Taxpayer] ON 

INSERT [dbo].[Taxpayer] ([Id], [FirstName], [LastName], [SSN], [PIN], [StartDate]) VALUES (1, N'Nicole', N'Bartlett', N'167-00-0992', N'1111', CAST(N'1974-02-18' AS Date))
INSERT [dbo].[Taxpayer] ([Id], [FirstName], [LastName], [SSN], [PIN], [StartDate]) VALUES (2, N'Christine', N'Rubio', N'784-74-2858', N'2222', CAST(N'2005-02-26' AS Date))
INSERT [dbo].[Taxpayer] ([Id], [FirstName], [LastName], [SSN], [PIN], [StartDate]) VALUES (3, N'Pablo', N'Werner', N'090-13-2722', N'3333', CAST(N'1954-11-13' AS Date))
INSERT [dbo].[Taxpayer] ([Id], [FirstName], [LastName], [SSN], [PIN], [StartDate]) VALUES (4, N'Darnell', N'Calderon', N'220-07-3275', N'4444', CAST(N'1966-05-14' AS Date))
INSERT [dbo].[Taxpayer] ([Id], [FirstName], [LastName], [SSN], [PIN], [StartDate]) VALUES (5, N'Desiree', N'Farmer', N'975-78-5848', N'5555', CAST(N'2007-12-10' AS Date))
INSERT [dbo].[Taxpayer] ([Id], [FirstName], [LastName], [SSN], [PIN], [StartDate]) VALUES (6, N'Holly', N'Fernandez', N'048-99-5562', N'6666', CAST(N'2008-12-24' AS Date))
INSERT [dbo].[Taxpayer] ([Id], [FirstName], [LastName], [SSN], [PIN], [StartDate]) VALUES (7, N'Chadwick', N'Trevino', N'302-04-3352', N'7777', CAST(N'2019-12-12' AS Date))
INSERT [dbo].[Taxpayer] ([Id], [FirstName], [LastName], [SSN], [PIN], [StartDate]) VALUES (8, N'Julie', N'Moreno', N'795-86-8498', N'8888', CAST(N'2000-04-12' AS Date))
INSERT [dbo].[Taxpayer] ([Id], [FirstName], [LastName], [SSN], [PIN], [StartDate]) VALUES (9, N'Daphne', N'Dudley', N'884-80-2406', N'9999', CAST(N'1972-09-28' AS Date))
INSERT [dbo].[Taxpayer] ([Id], [FirstName], [LastName], [SSN], [PIN], [StartDate]) VALUES (10, N'Jean', N'Trevino', N'535-24-4139', N'1235', CAST(N'2003-04-21' AS Date))
SET IDENTITY_INSERT [dbo].[Taxpayer] OFF
GO
USE [master]
GO
ALTER DATABASE [FluentValidation1] SET  READ_WRITE 
GO
