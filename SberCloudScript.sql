USE [master]
GO
/****** Object:  Database [SberCloud]    Script Date: 14.06.2021 2:55:32 ******/
CREATE DATABASE [SberCloud]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SberCloud', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SberCloud.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SberCloud_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SberCloud_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SberCloud] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SberCloud].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SberCloud] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SberCloud] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SberCloud] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SberCloud] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SberCloud] SET ARITHABORT OFF 
GO
ALTER DATABASE [SberCloud] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SberCloud] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SberCloud] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SberCloud] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SberCloud] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SberCloud] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SberCloud] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SberCloud] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SberCloud] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SberCloud] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SberCloud] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SberCloud] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SberCloud] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SberCloud] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SberCloud] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SberCloud] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SberCloud] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SberCloud] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SberCloud] SET  MULTI_USER 
GO
ALTER DATABASE [SberCloud] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SberCloud] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SberCloud] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SberCloud] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SberCloud] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SberCloud] SET QUERY_STORE = OFF
GO
USE [SberCloud]
GO
/****** Object:  Table [dbo].[Chat]    Script Date: 14.06.2021 2:55:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[DateCreated] [nvarchar](30) NOT NULL,
	[TypeId] [int] NOT NULL,
	[AdminId] [int] NULL,
 CONSTRAINT [PK_Chat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatUser]    Script Date: 14.06.2021 2:55:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ChatId] [int] NOT NULL,
 CONSTRAINT [PK_ChatUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 14.06.2021 2:55:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[CountryCode] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LawFirm]    Script Date: 14.06.2021 2:55:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LawFirm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PSRN] [bigint] NOT NULL,
	[INN] [bigint] NOT NULL,
	[Name] [nvarchar](70) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_LawFirm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 14.06.2021 2:55:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[ChatId] [int] NOT NULL,
	[Timestamp] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 14.06.2021 2:55:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 14.06.2021 2:55:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 14.06.2021 2:55:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 14.06.2021 2:55:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[MiddleName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[RoleId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[IpAddress] [nvarchar](15) NOT NULL,
	[RegionId] [int] NOT NULL,
	[Login] [nvarchar](25) NOT NULL,
	[Password] [nvarchar](25) NOT NULL,
	[LawFirmId] [int] NULL,
	[Email] [nvarchar](25) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Chat] ON 

INSERT [dbo].[Chat] ([Id], [Name], [DateCreated], [TypeId], [AdminId]) VALUES (2, N'Тест', N'1623597855', 1, 6)
INSERT [dbo].[Chat] ([Id], [Name], [DateCreated], [TypeId], [AdminId]) VALUES (3, N'Test2', N'5435345342', 1, 6)
INSERT [dbo].[Chat] ([Id], [Name], [DateCreated], [TypeId], [AdminId]) VALUES (9, N'TestChat', N'1623627265', 1, 6)
INSERT [dbo].[Chat] ([Id], [Name], [DateCreated], [TypeId], [AdminId]) VALUES (10, N'Evgenievich', N'1623638883', 1, 6)
SET IDENTITY_INSERT [dbo].[Chat] OFF
GO
SET IDENTITY_INSERT [dbo].[ChatUser] ON 

INSERT [dbo].[ChatUser] ([Id], [UserId], [ChatId]) VALUES (2, 6, 2)
INSERT [dbo].[ChatUser] ([Id], [UserId], [ChatId]) VALUES (3, 8, 2)
INSERT [dbo].[ChatUser] ([Id], [UserId], [ChatId]) VALUES (4, 6, 3)
INSERT [dbo].[ChatUser] ([Id], [UserId], [ChatId]) VALUES (11, 7, 3)
SET IDENTITY_INSERT [dbo].[ChatUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [Name], [CountryCode]) VALUES (1, N'Россия', N'1337')
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Message] ON 

INSERT [dbo].[Message] ([Id], [UserId], [Text], [ChatId], [Timestamp]) VALUES (29, 6, N'eeeeeeeooooooo', 2, N'324523553')
INSERT [dbo].[Message] ([Id], [UserId], [Text], [ChatId], [Timestamp]) VALUES (61, 6, N'uuuuuooooo', 3, N'849848974')
INSERT [dbo].[Message] ([Id], [UserId], [Text], [ChatId], [Timestamp]) VALUES (67, 6, N'324', 2, N'3124342342')
INSERT [dbo].[Message] ([Id], [UserId], [Text], [ChatId], [Timestamp]) VALUES (68, 6, N'tr', 2, N'42343243242')
INSERT [dbo].[Message] ([Id], [UserId], [Text], [ChatId], [Timestamp]) VALUES (69, 6, N'test message', 2, N'1623626064')
INSERT [dbo].[Message] ([Id], [UserId], [Text], [ChatId], [Timestamp]) VALUES (80, 6, N'Hi there', 2, N'1623637532')
INSERT [dbo].[Message] ([Id], [UserId], [Text], [ChatId], [Timestamp]) VALUES (83, 8, N'hey you', 2, N'1623626064')
INSERT [dbo].[Message] ([Id], [UserId], [Text], [ChatId], [Timestamp]) VALUES (84, 6, N'Heeey, last test', 2, N'1623639120')
SET IDENTITY_INSERT [dbo].[Message] OFF
GO
SET IDENTITY_INSERT [dbo].[Region] ON 

INSERT [dbo].[Region] ([Id], [Name]) VALUES (1, N'Москва')
INSERT [dbo].[Region] ([Id], [Name]) VALUES (2, N'Yana')
INSERT [dbo].[Region] ([Id], [Name]) VALUES (3, N'Ti')
INSERT [dbo].[Region] ([Id], [Name]) VALUES (4, N'sdelalal')
INSERT [dbo].[Region] ([Id], [Name]) VALUES (5, N'combobox')
INSERT [dbo].[Region] ([Id], [Name]) VALUES (6, N'molodec')
INSERT [dbo].[Region] ([Id], [Name]) VALUES (7, N'mm&')
SET IDENTITY_INSERT [dbo].[Region] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Разработчик')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Физическое лицо')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (3, N'Юридическое лицо')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([Id], [Name]) VALUES (1, N'Диалог')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (2, N'Групповой')
SET IDENTITY_INSERT [dbo].[Type] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FirstName], [MiddleName], [LastName], [RoleId], [CountryId], [IpAddress], [RegionId], [Login], [Password], [LawFirmId], [Email], [Phone]) VALUES (6, N'test', N'test', N'test', 1, 1, N'test', 1, N'test', N'test', NULL, N'test', N'test')
INSERT [dbo].[User] ([Id], [FirstName], [MiddleName], [LastName], [RoleId], [CountryId], [IpAddress], [RegionId], [Login], [Password], [LawFirmId], [Email], [Phone]) VALUES (7, N'yana', N'yana', N'yana', 1, 1, N'yana', 1, N'yana', N'yana', NULL, N'yana', N'yana')
INSERT [dbo].[User] ([Id], [FirstName], [MiddleName], [LastName], [RoleId], [CountryId], [IpAddress], [RegionId], [Login], [Password], [LawFirmId], [Email], [Phone]) VALUES (8, N'alo', N'alo', N'alo', 1, 1, N'neyana', 1, N'neyana', N'neyana', NULL, N'alo', N'alo')
INSERT [dbo].[User] ([Id], [FirstName], [MiddleName], [LastName], [RoleId], [CountryId], [IpAddress], [RegionId], [Login], [Password], [LawFirmId], [Email], [Phone]) VALUES (1354, N'Stanislav', N'Evgenievich', N'Makievskiy', 1, 1, N'109.252.129.160', 1, N'dantejke2', N'123', NULL, N'burnfeniks@yandex.ru', N'+79964159842')
INSERT [dbo].[User] ([Id], [FirstName], [MiddleName], [LastName], [RoleId], [CountryId], [IpAddress], [RegionId], [Login], [Password], [LawFirmId], [Email], [Phone]) VALUES (1365, N'Денис', N'Иванович', N'Дмитриев', 1, 1, N'127.0.0.1', 1, N'deniska', N'123', NULL, N'1', N'1')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD  CONSTRAINT [FK_Chat_Type] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type] ([Id])
GO
ALTER TABLE [dbo].[Chat] CHECK CONSTRAINT [FK_Chat_Type]
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD  CONSTRAINT [FK_Chat_User] FOREIGN KEY([AdminId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Chat] CHECK CONSTRAINT [FK_Chat_User]
GO
ALTER TABLE [dbo].[ChatUser]  WITH CHECK ADD  CONSTRAINT [FK_ChatUser_Chat] FOREIGN KEY([ChatId])
REFERENCES [dbo].[Chat] ([Id])
GO
ALTER TABLE [dbo].[ChatUser] CHECK CONSTRAINT [FK_ChatUser_Chat]
GO
ALTER TABLE [dbo].[ChatUser]  WITH CHECK ADD  CONSTRAINT [FK_ChatUser_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ChatUser] CHECK CONSTRAINT [FK_ChatUser_User]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Chat] FOREIGN KEY([ChatId])
REFERENCES [dbo].[Chat] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Chat]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Country]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_LawFirm] FOREIGN KEY([LawFirmId])
REFERENCES [dbo].[LawFirm] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_LawFirm]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Region] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Region] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Region]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [SberCloud] SET  READ_WRITE 
GO
