/*
Component :                             Database script that is used for creating our project's database and necessary tables
Author:                                 Sreedevi Koppula
Use of the component in system design:  Specifies the structure of the database that stores our project's data
Written and revised:                    11/9/2016
Reason for component existence:         To create project's database and necessary tables 
Component usage of data structures, algorithms and control(if any): 
    Contains the SQL queries for performing the below actions:
		Create Database - 'DSE' 
		Create tables - User, Group, User_Group, User_Request, Activity, Question, Answer
*/

/* Creating our project's database. Name of the database - DSE */
CREATE DATABASE [DSE]
GO 

USE [DSE]
GO

/****** Object:  Table [dbo].[Activity]    Script Date: 11/18/2016 10:43:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User_Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[role] [int] NOT NULL,
	[emailId] [nvarchar](50) NOT NULL,
	[pwd] [nvarchar](50) NOT NULL,
	[status] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User_Roles] FOREIGN KEY([role])
REFERENCES [dbo].[User_Roles] ([id])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User_Roles]
GO

CREATE UNIQUE NONCLUSTERED INDEX [Unique_User] ON [dbo].[User]
(
	[emailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO



CREATE TABLE [dbo].[Activity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[heading] [nvarchar](300) NOT NULL,
	[description] [nvarchar](1000) NULL,
	[type] [int] NOT NULL,
	[category] [int] NOT NULL,
	[createdby] [int] NOT NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Category] FOREIGN KEY([category])
REFERENCES [dbo].[Category] ([id])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Category]
GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Type] FOREIGN KEY([type])
REFERENCES [dbo].[Type] ([id])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Type]
GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_User] FOREIGN KEY([createdby])
REFERENCES [dbo].[User] ([id])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_User]
GO

CREATE TABLE [dbo].[Group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](300) NOT NULL,
	[createdby] [int] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_User] FOREIGN KEY([createdby])
REFERENCES [dbo].[User] ([id])
GO

ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_User]
GO


CREATE TABLE [dbo].[Activity_Group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[activity_id] [int] NOT NULL,
	[group_id] [int] NOT NULL,
 CONSTRAINT [PK_Activity_Group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Activity_Group]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Group_Activity] FOREIGN KEY([activity_id])
REFERENCES [dbo].[Activity] ([id])
GO

ALTER TABLE [dbo].[Activity_Group] CHECK CONSTRAINT [FK_Activity_Group_Activity]
GO

ALTER TABLE [dbo].[Activity_Group]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Group_Group] FOREIGN KEY([group_id])
REFERENCES [dbo].[Group] ([id])
GO

ALTER TABLE [dbo].[Activity_Group] CHECK CONSTRAINT [FK_Activity_Group_Group]
GO

CREATE TABLE [dbo].[Question](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](1000) NULL,
	[activity_id] [int] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Activity] FOREIGN KEY([activity_id])
REFERENCES [dbo].[Activity] ([id])
GO

ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Activity]
GO


CREATE TABLE [dbo].[Answer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](500) NULL,
	[question_id] [int] NOT NULL,
	[activity_id] [int] NOT NULL,
	[count] [int] NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Activity] FOREIGN KEY([activity_id])
REFERENCES [dbo].[Activity] ([id])
GO

ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Activity]
GO

ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([id])
GO

ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO


CREATE TABLE [dbo].[User_Answer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[activity_id] [int] NOT NULL,
	[question_id] [int] NOT NULL,
	[answer_id] [int] NOT NULL,
 CONSTRAINT [PK_User_Answer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[User_Answer]  WITH CHECK ADD  CONSTRAINT [FK_User_Answer_Answer] FOREIGN KEY([answer_id])
REFERENCES [dbo].[Answer] ([id])
GO

ALTER TABLE [dbo].[User_Answer] CHECK CONSTRAINT [FK_User_Answer_Answer]
GO

ALTER TABLE [dbo].[User_Answer]  WITH CHECK ADD  CONSTRAINT [FK_User_Answer_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO

ALTER TABLE [dbo].[User_Answer] CHECK CONSTRAINT [FK_User_Answer_User]
GO

ALTER TABLE [dbo].[User_Answer]  WITH CHECK ADD  CONSTRAINT [FK_User_Answer_User_Activity] FOREIGN KEY([activity_id])
REFERENCES [dbo].[Activity] ([id])
GO

ALTER TABLE [dbo].[User_Answer] CHECK CONSTRAINT [FK_User_Answer_User_Activity]
GO

ALTER TABLE [dbo].[User_Answer]  WITH CHECK ADD  CONSTRAINT [FK_User_Answer_User_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([id])
GO

ALTER TABLE [dbo].[User_Answer] CHECK CONSTRAINT [FK_User_Answer_User_Question]
GO



CREATE TABLE [dbo].[User_Group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[group_id] [int] NOT NULL,
 CONSTRAINT [PK_User_Group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_Group] FOREIGN KEY([group_id])
REFERENCES [dbo].[Group] ([id])
GO

ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_User_Group_Group]
GO

ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO

ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_User_Group_User]
GO


CREATE TABLE [dbo].[User_Request](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[description] [nvarchar](1000) NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_User_Request] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[User_Request]  WITH CHECK ADD  CONSTRAINT [FK_User_Request_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO

ALTER TABLE [dbo].[User_Request] CHECK CONSTRAINT [FK_User_Request_User]
GO


insert into dbo.[user_roles] values ('basicUser')
insert into dbo.[user_roles] values ('groupLeader')
insert into dbo.[user_roles] values ('admin')


insert into dbo.[category] values('Poll')
insert into dbo.[category] values('Survey')

insert into dbo.[type] values('Public')
insert into dbo.[type] values('Private')

alter table dbo.[activity] add results_published integer



