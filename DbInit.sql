USE [master]
GO
/****** Object:  Database [Snappet]    Script Date: 10/4/2015 7:42:07 PM ******/
CREATE DATABASE [Snappet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Snappet', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Snappet.mdf' , SIZE = 27648KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Snappet_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Snappet_log.ldf' , SIZE = 35712KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Snappet] SET COMPATIBILITY_LEVEL = 110
GO

USE [Snappet]
GO
/****** Object:  StoredProcedure [dbo].[sp_getUsers]    Script Date: 10/4/2015 7:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getUsers]
	@startTime datetime,
	@endTime datetime,
	@domainId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT UserId, SubjectId, count(Id) as TotalAnswers, 
  (Select COUNT(id)  FROM [Snappet].[dbo].ExerciseResult uu WHERE uu.UserId = u.UserId AND uu.SubjectId = u.SubjectId AND uu.IsCorrect = 1
  AND uu.SubmitDateTime > @startTime AND uu.SubmitDateTime < @endTime AND uu.DomainId = @domainId) AS CorrectAnswers
  FROM [Snappet].[dbo].[ExerciseResult] u 
  where u.SubmitDateTime > @startTime AND u.SubmitDateTime < @endTime AND u.DomainId = @domainId
  group by userid , subjectid
  order by UserId
END

GO
/****** Object:  Table [dbo].[Domain]    Script Date: 10/4/2015 7:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domain](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Domain] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExerciseResult]    Script Date: 10/4/2015 7:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubmittedAnswerId] [int] NOT NULL,
	[SubmitDateTime] [datetime] NOT NULL,
	[IsCorrect] [bit] NOT NULL,
	[Progress] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ExerciseId] [int] NOT NULL,
	[Difficulty] [decimal](14, 7) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[DomainId] [int] NOT NULL,
	[LearningObjectiveId] [int] NOT NULL,
 CONSTRAINT [PK_ExerciseResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LearningObjective]    Script Date: 10/4/2015 7:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LearningObjective](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_LearningObjective] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 10/4/2015 7:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ExerciseResult]  WITH CHECK ADD  CONSTRAINT [FK_ExerciseResult_Domain] FOREIGN KEY([DomainId])
REFERENCES [dbo].[Domain] ([Id])
GO
ALTER TABLE [dbo].[ExerciseResult] CHECK CONSTRAINT [FK_ExerciseResult_Domain]
GO
ALTER TABLE [dbo].[ExerciseResult]  WITH CHECK ADD  CONSTRAINT [FK_ExerciseResult_LearningObjective] FOREIGN KEY([LearningObjectiveId])
REFERENCES [dbo].[LearningObjective] ([Id])
GO
ALTER TABLE [dbo].[ExerciseResult] CHECK CONSTRAINT [FK_ExerciseResult_LearningObjective]
GO
ALTER TABLE [dbo].[ExerciseResult]  WITH CHECK ADD  CONSTRAINT [FK_ExerciseResult_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[ExerciseResult] CHECK CONSTRAINT [FK_ExerciseResult_Subject]
GO
USE [master]
GO
ALTER DATABASE [Snappet] SET  READ_WRITE 
GO
