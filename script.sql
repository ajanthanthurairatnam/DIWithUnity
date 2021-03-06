USE [ReminderDB]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserReminder_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserReminder]'))
ALTER TABLE [dbo].[UserReminder] DROP CONSTRAINT [FK_UserReminder_User]
GO
/****** Object:  Table [dbo].[UserReminder]    Script Date: 11/01/2018 11:08:20 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserReminder]') AND type in (N'U'))
DROP TABLE [dbo].[UserReminder]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/01/2018 11:08:20 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/01/2018 11:08:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserReminder]    Script Date: 11/01/2018 11:08:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserReminder]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserReminder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Reminder] [varchar](max) NOT NULL,
	[ReminderDate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserReminder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName]) VALUES (1, N'yyyy')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserReminder] ON 

INSERT [dbo].[UserReminder] ([ID], [UserID], [Reminder], [ReminderDate]) VALUES (0, 1, N'weee', CAST(N'2018-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[UserReminder] ([ID], [UserID], [Reminder], [ReminderDate]) VALUES (2, 1, N'333', CAST(N'2011-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[UserReminder] ([ID], [UserID], [Reminder], [ReminderDate]) VALUES (3, 1, N'eee', CAST(N'2019-02-12 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserReminder] OFF
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserReminder_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserReminder]'))
ALTER TABLE [dbo].[UserReminder]  WITH CHECK ADD  CONSTRAINT [FK_UserReminder_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserReminder_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserReminder]'))
ALTER TABLE [dbo].[UserReminder] CHECK CONSTRAINT [FK_UserReminder_User]
GO
