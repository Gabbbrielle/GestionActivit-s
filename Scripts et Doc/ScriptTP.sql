USE [master]
GO
/****** Object:  Database [Activities]    Script Date: 20-Dec-2021 10:14:20 AM ******/
CREATE DATABASE [Activities]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Activities', FILENAME = N'D:\datadb\MSSQL13.MSSQLSERVER\MSSQL\DATA\Activities.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Activities_log', FILENAME = N'D:\datadb\MSSQL13.MSSQLSERVER\MSSQL\DATA\Activities_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Activities] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Activities].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Activities] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Activities] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Activities] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Activities] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Activities] SET ARITHABORT OFF 
GO
ALTER DATABASE [Activities] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Activities] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Activities] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Activities] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Activities] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Activities] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Activities] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Activities] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Activities] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Activities] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Activities] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Activities] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Activities] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Activities] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Activities] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Activities] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Activities] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Activities] SET RECOVERY FULL 
GO
ALTER DATABASE [Activities] SET  MULTI_USER 
GO
ALTER DATABASE [Activities] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Activities] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Activities] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Activities] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Activities] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Activities', N'ON'
GO
ALTER DATABASE [Activities] SET QUERY_STORE = OFF
GO
USE [Activities]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Activities]
GO
/****** Object:  Table [dbo].[Activities]    Script Date: 20-Dec-2021 10:14:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activities](
	[ActivityID] [int] IDENTITY(1,1) NOT NULL,
	[NomActivite] [nchar](50) NOT NULL,
	[Emplacement] [nchar](100) NOT NULL,
	[DateActivite] [date] NOT NULL,
	[Debut] [datetime] NOT NULL,
	[Fin] [datetime] NOT NULL,
	[Prix] [money] NOT NULL,
	[Vote] [int] NOT NULL,
	[Covoiturage] [int] NOT NULL,
	[PlaceVoiture] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participants]    Script Date: 20-Dec-2021 10:14:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nchar](50) NOT NULL,
	[Activite] [nchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Activities] ADD  DEFAULT ((0)) FOR [Prix]
GO
ALTER TABLE [dbo].[Activities] ADD  DEFAULT ((0)) FOR [Vote]
GO
ALTER TABLE [dbo].[Activities] ADD  DEFAULT ((0)) FOR [Covoiturage]
GO
ALTER TABLE [dbo].[Activities] ADD  DEFAULT ((0)) FOR [PlaceVoiture]
GO
/****** Object:  StoredProcedure [dbo].[CountVotes]    Script Date: 20-Dec-2021 10:14:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CountVotes]
	
	
AS
begin
	SELECT count(*) from Participants;
end
GO
/****** Object:  StoredProcedure [dbo].[CreateParticipant]    Script Date: 20-Dec-2021 10:14:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateParticipant] 
	-- Add the parameters for the stored procedure here
	@Param1 nchar(50), 
	@Param2 nchar(50)
AS
BEGIN
	
	insert into Participants(Nom, Activite)
		values(@Param1, @Param2);
	update Activities 
		set Vote = Vote +1
		where NomActivite = @Param2;
END
GO
/****** Object:  StoredProcedure [dbo].[GetDetails]    Script Date: 20-Dec-2021 10:14:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDetails] 
	@ActivityID int
AS
BEGIN
	select * from Activities
	where ActivityID = @ActivityID
END

GO
/****** Object:  StoredProcedure [dbo].[GetListActivities]    Script Date: 20-Dec-2021 10:14:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetListActivities]
	
AS
BEGIN
	select *
	
	from Activities
	order by Vote desc
END
GO
/****** Object:  StoredProcedure [dbo].[GetParticipants]    Script Date: 20-Dec-2021 10:14:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetParticipants] 
	
AS
BEGIN
	
	SET NOCOUNT ON;
	Select * from Participants
	order by Activite
END
GO
USE [master]
GO
ALTER DATABASE [Activities] SET  READ_WRITE 
GO
