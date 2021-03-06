USE [master]
GO
/****** Object:  Database [universityManagementSystem]    Script Date: 4/1/2018 11:34:47 PM ******/
CREATE DATABASE [universityManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'universityManagementSystem', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\universityManagementSystem.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'universityManagementSystem_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\universityManagementSystem_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [universityManagementSystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [universityManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [universityManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [universityManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [universityManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [universityManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [universityManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [universityManagementSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [universityManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [universityManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [universityManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [universityManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [universityManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [universityManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [universityManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [universityManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [universityManagementSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [universityManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [universityManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [universityManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [universityManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [universityManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [universityManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [universityManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [universityManagementSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [universityManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [universityManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [universityManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [universityManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [universityManagementSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [universityManagementSystem]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 4/1/2018 11:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrator](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignedCourses]    Script Date: 4/1/2018 11:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignedCourses](
	[CourseCode] [int] NULL,
	[FacultyID] [int] NULL,
	[AssignedBy] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 4/1/2018 11:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[StudentID] [int] NULL,
	[SectionID] [int] NULL,
	[Session1] [varchar](10) NULL,
	[Session2] [varchar](10) NULL,
	[WeekNo] [int] NULL,
	[ModificationDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 4/1/2018 11:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](10) NOT NULL,
	[CreditHour] [int] NOT NULL,
	[dateOfCreation] [datetime] NOT NULL,
	[DepartmentID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 4/1/2018 11:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](10) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[AddedBy] [int] NULL,
	[HOD] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 4/1/2018 11:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[CourseCode] [int] NULL,
	[StudentID] [int] NULL,
	[SectionNo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 4/1/2018 11:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[FacultyID] [int] IDENTITY(1,1) NOT NULL,
	[AreaOfWork] [int] NOT NULL,
	[Qualification] [int] NOT NULL,
	[Experience] [int] NOT NULL,
	[AccountID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FacultyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marks]    Script Date: 4/1/2018 11:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marks](
	[QuizesAndAssignments] [int] NULL,
	[Project] [int] NULL,
	[MidTerm] [int] NULL,
	[Final] [int] NULL,
	[dateOfCreation] [datetime] NOT NULL,
	[CourseCode] [int] NULL,
	[StudentID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Section]    Script Date: 4/1/2018 11:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section](
	[SectionNo] [int] IDENTITY(1,1) NOT NULL,
	[Timings] [varchar](10) NOT NULL,
	[Date] [date] NOT NULL,
	[dateOfCreation] [datetime] NOT NULL,
	[CourseCode] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SectionNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 4/1/2018 11:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[Department] [varchar](1) NOT NULL,
	[Qualification] [varchar](1) NOT NULL,
	[Experience] [int] NOT NULL,
	[AccountID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 4/1/2018 11:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[DOB] [date] NOT NULL,
	[AddedBy] [varchar](10) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[AccountType] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Attendance] ADD  DEFAULT (getdate()) FOR [ModificationDate]
GO
ALTER TABLE [dbo].[Course] ADD  DEFAULT (getdate()) FOR [dateOfCreation]
GO
ALTER TABLE [dbo].[Department] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Marks] ADD  DEFAULT (getdate()) FOR [dateOfCreation]
GO
ALTER TABLE [dbo].[Section] ADD  DEFAULT (getdate()) FOR [dateOfCreation]
GO
ALTER TABLE [dbo].[Administrator]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[UserAccount] ([AccountID])
GO
ALTER TABLE [dbo].[AssignedCourses]  WITH CHECK ADD FOREIGN KEY([AssignedBy])
REFERENCES [dbo].[Administrator] ([AdminID])
GO
ALTER TABLE [dbo].[AssignedCourses]  WITH CHECK ADD FOREIGN KEY([CourseCode])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[AssignedCourses]  WITH CHECK ADD FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculty] ([FacultyID])
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD FOREIGN KEY([SectionID])
REFERENCES [dbo].[Section] ([SectionNo])
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD FOREIGN KEY([AddedBy])
REFERENCES [dbo].[Administrator] ([AdminID])
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD FOREIGN KEY([HOD])
REFERENCES [dbo].[Faculty] ([FacultyID])
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD FOREIGN KEY([CourseCode])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD FOREIGN KEY([SectionNo])
REFERENCES [dbo].[Section] ([SectionNo])
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[Faculty]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[UserAccount] ([AccountID])
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD FOREIGN KEY([CourseCode])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[Section]  WITH CHECK ADD FOREIGN KEY([CourseCode])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[UserAccount] ([AccountID])
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD CHECK  (([Session1]='A' OR [Session1]='P'))
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD CHECK  (([Session2]='A' OR [Session2]='P'))
GO
ALTER TABLE [dbo].[UserAccount]  WITH CHECK ADD CHECK  (([AccountType]='Student' OR [AccountType]='Faculty' OR [AccountType]='Admin'))
GO
USE [master]
GO
ALTER DATABASE [universityManagementSystem] SET  READ_WRITE 
GO
