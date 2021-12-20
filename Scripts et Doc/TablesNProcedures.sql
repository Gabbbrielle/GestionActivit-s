USE [Activities]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/****** Object:  Table [dbo].[Participants]    Script Date: 12-Dec-2021 10:08:06 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Participants]') AND type in (N'U'))
DROP TABLE [dbo].[Participants]
GO

/****** Object:  Table [dbo].[Participants]    Script Date: 12-Dec-2021 10:08:06 AM ******/


CREATE TABLE [dbo].[Participants](
	[Id] [int] NOT NULL primary key identity,
	[Prenom] [nchar](50) NOT NULL,
	[Nom] [nchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Voiture] [int] NULL,
	[PlaceVoiture] [int] NULL,
	[Vote] [int] NULL
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[Participants]    Script Date: 19-Dec-2021 12:11:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Participants]') AND type in (N'U'))
DROP TABLE [dbo].[Participants]
GO

/****** Object:  Table [dbo].[Participants]    Script Date: 19-Dec-2021 12:11:03 PM ******/


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


/****** Object:  StoredProcedure [dbo].[CountVotes]    Script Date: 19-Dec-2021 12:11:42 PM ******/

/****** Object:  StoredProcedure [dbo].[CountVotes]    Script Date: 19-Dec-2021 12:11:42 PM ******/

CREATE PROCEDURE [dbo].[CountVotes]
	
	
AS
begin
	SELECT count(*) from Participants;
end
GO

USE [Activities]
GO

/****** Object:  StoredProcedure [dbo].[CreateParticipant]    Script Date: 19-Dec-2021 12:12:34 PM ******/


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

USE [Activities]
GO

/****** Object:  StoredProcedure [dbo].[GetDetails]    Script Date: 19-Dec-2021 12:15:23 PM ******/

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

USE [Activities]
GO

/****** Object:  StoredProcedure [dbo].[GetListActivities]    Script Date: 19-Dec-2021 12:16:04 PM ******/


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

USE [Activities]
GO

/****** Object:  StoredProcedure [dbo].[GetParticipants]    Script Date: 19-Dec-2021 12:16:57 PM ******/


CREATE PROCEDURE [dbo].[GetParticipants] 
	
AS
BEGIN
	
	SET NOCOUNT ON;
	Select * from Participants
	order by Activite
END
GO














