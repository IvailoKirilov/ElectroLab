USE [master]
GO
/****** Object:  Database [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET ARITHABORT OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET  ENABLE_BROKER 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET RECOVERY FULL 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET  MULTI_USER 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4', N'ON'
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET QUERY_STORE = ON
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bans]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bans](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[BanDate] [datetime2](7) NOT NULL,
	[ExpiryDate] [datetime2](7) NULL,
	[Reason] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Bans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ContentHtml] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Time] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Options] [nvarchar](max) NOT NULL,
	[CorrectAnswer] [nvarchar](max) NOT NULL,
	[TestId] [int] NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[ReportContent] [nvarchar](max) NOT NULL,
	[ReportType] [nvarchar](max) NULL,
	[ReportStatus] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubmissionAnswers]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubmissionAnswers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Answer] [nvarchar](max) NOT NULL,
	[IsCorrect] [bit] NOT NULL,
	[QuestionId] [int] NULL,
	[SubmissionId] [int] NULL,
	[QuestionId1] [int] NULL,
	[SubmissionId1] [int] NULL,
 CONSTRAINT [PK_SubmissionAnswers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Submissions]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Submissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[Score] [int] NOT NULL,
	[TestId1] [int] NULL,
	[DateSubmitted] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Submissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tests]    Script Date: 2/28/2025 9:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250202101124_InitialMigration', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250202101624_AddedDate', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250202102729_ChangedCascade1', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250202111535_FixSubmissionId1', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250209164341_AddedReports', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250209170026_ReleationsReport', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250210145506_NullableReportType', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250210180827_RemovedFieldsReport', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250215121450_test', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250215121544_RemoveTest', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250228161139_ModerationTools', N'8.0.11')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3108ab76-fca7-4fa8-bbed-977fb03c826d', N'Admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'84162b42-5065-4d54-8980-bbf6a7202e83', N'Owner', N'OWNER', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'736062bf-62d1-4e20-921f-dd04019db589', N'84162b42-5065-4d54-8980-bbf6a7202e83')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'736062bf-62d1-4e20-921f-dd04019db589', N'georgi170109', N'GEORGI170109', N'gogo170109@gmail.com', N'GOGO170109@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEHjeeQTdE1nWnT8BzbtujFtpdkNGetrC2u/wonCY27kCpgTOceodsb2FI8QN1gOSYA==', N'JQJZXIZ3GNGLCC5Q34BGYEWJONL6FYAG', N'69c3b195-5b20-4a49-9d1a-f3e7b53ba6b3', NULL, 0, 0, CAST(N'2025-03-07T16:50:13.8981852+00:00' AS DateTimeOffset), 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd375e989-8f6d-4a17-b82c-106161b83a9b', N'Test123', N'TEST123', N'test@gmail.com', N'test@gmail.com', 0, N'AQAAAAIAAYagAAAAED7YrU4vPem0kJTxADiXSKWJtIFOHMkxPG/BQKhizpRNSwn17FtjiC1w5YBNZTmFEA==', N'UNOTGHVSKM4VZYJPGUJGVY6NYNUDPISH', N'5a200e58-f6b8-4a08-a286-257bb9e2f75b', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Title], [Description], [ContentHtml], [UserId]) VALUES (1, N'Introduction to Arduino and Basic Circuitry', N'Arduino is an open-source electronics platform based on easy-to-use hardware and software. It allows users to create interactive projects through simple coding and circuitry. This article will walk you through the basics of Arduino and how to set up your first circuit, making it a great starting point for beginners interested in electronics and programming.', N'<h4><strong>1. What is Arduino?</strong></h4>
<p>Arduino is an open-source electronics platform designed for creating interactive objects and environments. It consists of both a microcontroller board and an integrated development environment (IDE) used to program it. The platform can be used for various applications, from simple projects like blinking LEDs to complex devices like robots or automated systems.</p>
<h4><strong>2. Setting Up Your First Circuit</strong></h4>
<p>To begin, you need an Arduino board, breadboard, jumper wires, and components like resistors and LEDs. Start by connecting the long leg of an LED to a digital pin on the Arduino board and the short leg to the ground (GND) through a resistor. This is your basic circuit.</p>
<h4><strong>3. Writing Code for the Circuit</strong></h4>
<p>In the Arduino IDE, you will write a simple program (called a sketch) to control the LED. Here''s an example of code that will make the LED blink every second:</p>
<div class="contain-inline-size rounded-md border-[0.5px] border-token-border-medium relative bg-token-sidebar-surface-primary dark:bg-gray-950">
<div class="sticky top-9 md:top-[5.75rem]">
<div class="absolute bottom-0 right-2 flex h-9 items-center">
<div class="flex items-center rounded bg-token-sidebar-surface-primary px-2 font-sans text-xs text-token-text-secondary dark:bg-token-main-surface-secondary"><code class="!whitespace-pre language-cpp"><span class="hljs-function"><span class="hljs-type">void</span> <span class="hljs-title">setup</span><span class="hljs-params">()</span> </span>{
  <span class="hljs-built_in">pinMode</span>(<span class="hljs-number">13</span>, OUTPUT);  <span class="hljs-comment">// Set pin 13 as an output</span>
}

<span class="hljs-function"><span class="hljs-type">void</span> <span class="hljs-title">loop</span><span class="hljs-params">()</span> </span>{
  <span class="hljs-built_in">digitalWrite</span>(<span class="hljs-number">13</span>, HIGH);   <span class="hljs-comment">// Turn on LED</span>
  <span class="hljs-built_in">delay</span>(<span class="hljs-number">1000</span>);               <span class="hljs-comment">// Wait for a second</span>
  <span class="hljs-built_in">digitalWrite</span>(<span class="hljs-number">13</span>, LOW);    <span class="hljs-comment">// Turn off LED</span>
  <span class="hljs-built_in">delay</span>(<span class="hljs-number">1000</span>);               <span class="hljs-comment">// Wait for a second</span>
}
</code></div>
</div>
</div>
</div>
<p>Upload the code to the Arduino board, and the LED should start blinking.</p>
<h4><strong>4. Expanding Your Projects</strong></h4>
<p>Once you''ve mastered the basics, you can start exploring more advanced projects such as controlling motors, reading sensor data, or sending data to a computer. The possibilities are endless with Arduino!</p>', N'736062bf-62d1-4e20-921f-dd04019db589')
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([Id], [Action], [UserName], [Time]) VALUES (1, N'User Banned', N'georgi170109', CAST(N'2025-02-28T18:50:13.9834227' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Logs] OFF
GO
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([Id], [Text], [Options], [CorrectAnswer], [TestId]) VALUES (1, N'What is the main purpose of an Arduino board?', N'["To store large amounts of data","To create interactive projects","To control the power supply of devices","To replace a computer processor"]', N'Option 2', 1)
INSERT [dbo].[Questions] ([Id], [Text], [Options], [CorrectAnswer], [TestId]) VALUES (2, N'Which component is required to connect an LED to an Arduino board?', N'["Diode","Capacitor","Resistor","Potentiometer"]', N'Option 3', 1)
INSERT [dbo].[Questions] ([Id], [Text], [Options], [CorrectAnswer], [TestId]) VALUES (3, N'In the example code provided, what does the pinMode(13, OUTPUT) line do?', N'["Reads the voltage of pin 13","Sets pin 13 as an output","Initializes the Arduino board","Turns off pin 13"]', N'Option 2', 1)
INSERT [dbo].[Questions] ([Id], [Text], [Options], [CorrectAnswer], [TestId]) VALUES (4, N'What is the purpose of the delay(1000) function in the code?', N'["It makes the LED blink","It pauses the program for 1000 milliseconds (1 second)","It measures the temperature of the sensor","It increases the brightness of the LED"]', N'Option 2', 1)
INSERT [dbo].[Questions] ([Id], [Text], [Options], [CorrectAnswer], [TestId]) VALUES (5, N'What can you do after you’ve mastered the basics of Arduino?', N'["Nothing, Arduino is just for beginners","Control complex systems and create advanced projects","Only use it to blink LEDs","Build robots with Arduino only"]', N'Option 2', 1)
SET IDENTITY_INSERT [dbo].[Questions] OFF
GO
SET IDENTITY_INSERT [dbo].[Reports] ON 

INSERT [dbo].[Reports] ([Id], [CourseId], [ReportContent], [ReportType], [ReportStatus], [UserId]) VALUES (11, 1, N'asdad', NULL, N'Handled', N'736062bf-62d1-4e20-921f-dd04019db589')
SET IDENTITY_INSERT [dbo].[Reports] OFF
GO
SET IDENTITY_INSERT [dbo].[Tests] ON 

INSERT [dbo].[Tests] ([Id], [Title], [CourseId]) VALUES (1, N'Introduction to Arduino and Basic Circuitry', 1)
SET IDENTITY_INSERT [dbo].[Tests] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Bans_UserId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bans_UserId] ON [dbo].[Bans]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Courses_UserId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Courses_UserId] ON [dbo].[Courses]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Questions_TestId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Questions_TestId] ON [dbo].[Questions]
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reports_CourseId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reports_CourseId] ON [dbo].[Reports]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reports_UserId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reports_UserId] ON [dbo].[Reports]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubmissionAnswers_QuestionId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_SubmissionAnswers_QuestionId] ON [dbo].[SubmissionAnswers]
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubmissionAnswers_QuestionId1]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_SubmissionAnswers_QuestionId1] ON [dbo].[SubmissionAnswers]
(
	[QuestionId1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubmissionAnswers_SubmissionId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_SubmissionAnswers_SubmissionId] ON [dbo].[SubmissionAnswers]
(
	[SubmissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubmissionAnswers_SubmissionId1]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_SubmissionAnswers_SubmissionId1] ON [dbo].[SubmissionAnswers]
(
	[SubmissionId1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Submissions_TestId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Submissions_TestId] ON [dbo].[Submissions]
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Submissions_TestId1]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Submissions_TestId1] ON [dbo].[Submissions]
(
	[TestId1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Submissions_UserId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Submissions_UserId] ON [dbo].[Submissions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tests_CourseId]    Script Date: 2/28/2025 9:14:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tests_CourseId] ON [dbo].[Tests]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reports] ADD  DEFAULT (N'') FOR [UserId]
GO
ALTER TABLE [dbo].[Submissions] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DateSubmitted]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Bans]  WITH CHECK ADD  CONSTRAINT [FK_Bans_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bans] CHECK CONSTRAINT [FK_Bans_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Tests_TestId] FOREIGN KEY([TestId])
REFERENCES [dbo].[Tests] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Tests_TestId]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_Courses_CourseId]
GO
ALTER TABLE [dbo].[SubmissionAnswers]  WITH CHECK ADD  CONSTRAINT [FK_SubmissionAnswers_Questions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
GO
ALTER TABLE [dbo].[SubmissionAnswers] CHECK CONSTRAINT [FK_SubmissionAnswers_Questions_QuestionId]
GO
ALTER TABLE [dbo].[SubmissionAnswers]  WITH CHECK ADD  CONSTRAINT [FK_SubmissionAnswers_Questions_QuestionId1] FOREIGN KEY([QuestionId1])
REFERENCES [dbo].[Questions] ([Id])
GO
ALTER TABLE [dbo].[SubmissionAnswers] CHECK CONSTRAINT [FK_SubmissionAnswers_Questions_QuestionId1]
GO
ALTER TABLE [dbo].[SubmissionAnswers]  WITH CHECK ADD  CONSTRAINT [FK_SubmissionAnswers_Submissions_SubmissionId] FOREIGN KEY([SubmissionId])
REFERENCES [dbo].[Submissions] ([Id])
GO
ALTER TABLE [dbo].[SubmissionAnswers] CHECK CONSTRAINT [FK_SubmissionAnswers_Submissions_SubmissionId]
GO
ALTER TABLE [dbo].[SubmissionAnswers]  WITH CHECK ADD  CONSTRAINT [FK_SubmissionAnswers_Submissions_SubmissionId1] FOREIGN KEY([SubmissionId1])
REFERENCES [dbo].[Submissions] ([Id])
GO
ALTER TABLE [dbo].[SubmissionAnswers] CHECK CONSTRAINT [FK_SubmissionAnswers_Submissions_SubmissionId1]
GO
ALTER TABLE [dbo].[Submissions]  WITH CHECK ADD  CONSTRAINT [FK_Submissions_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Submissions] CHECK CONSTRAINT [FK_Submissions_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Submissions]  WITH CHECK ADD  CONSTRAINT [FK_Submissions_Tests_TestId] FOREIGN KEY([TestId])
REFERENCES [dbo].[Tests] ([Id])
GO
ALTER TABLE [dbo].[Submissions] CHECK CONSTRAINT [FK_Submissions_Tests_TestId]
GO
ALTER TABLE [dbo].[Submissions]  WITH CHECK ADD  CONSTRAINT [FK_Submissions_Tests_TestId1] FOREIGN KEY([TestId1])
REFERENCES [dbo].[Tests] ([Id])
GO
ALTER TABLE [dbo].[Submissions] CHECK CONSTRAINT [FK_Submissions_Tests_TestId1]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_Tests_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_Tests_Courses_CourseId]
GO
USE [master]
GO
ALTER DATABASE [aspnet-ElectroLab-0115555e-ece2-4725-9f41-5b8a808f1bd4] SET  READ_WRITE 
GO
