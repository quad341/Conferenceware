USE [Conferenceware]
GO
/****** Object:  Table [dbo].[People]    Script Date: 02/22/2010 21:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[phone_number] [nchar](12) NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 02/22/2010 21:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[max_capacity] [int] NOT NULL,
	[building_name] [nvarchar](255) NOT NULL,
	[room_number] [nvarchar](255) NOT NULL,
	[notes] [ntext] NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 02/22/2010 21:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foods](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TShirtSizes]    Script Date: 02/22/2010 21:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TShirtSizes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TShirtSizes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeSlots]    Script Date: 02/22/2010 21:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlots](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[start_time] [datetime] NOT NULL,
	[end_time] [datetime] NOT NULL,
 CONSTRAINT [PK_TimeSlots] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Speakers]    Script Date: 02/22/2010 21:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Speakers](
	[person_id] [int] NOT NULL,
 CONSTRAINT [PK_Speakers] PRIMARY KEY CLUSTERED 
(
	[person_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 02/22/2010 21:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[description] [ntext] NOT NULL,
	[max_attendees] [int] NOT NULL,
	[timeslot_id] [int] NOT NULL,
	[location_id] [int] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendees]    Script Date: 02/22/2010 21:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendees](
	[person_id] [int] NOT NULL,
	[food_choice_id] [int] NOT NULL,
	[tshirt_id] [int] NOT NULL,
 CONSTRAINT [PK_Attendees] PRIMARY KEY CLUSTERED 
(
	[person_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventsSpeakers]    Script Date: 02/22/2010 21:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventsSpeakers](
	[event_id] [int] NOT NULL,
	[speaker_id] [int] NOT NULL,
 CONSTRAINT [PK_EventsSpeakers] PRIMARY KEY CLUSTERED 
(
	[event_id] ASC,
	[speaker_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventsAttendees]    Script Date: 02/22/2010 21:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventsAttendees](
	[event_id] [int] NOT NULL,
	[attendee_id] [int] NOT NULL,
 CONSTRAINT [PK_EventsAttendees] PRIMARY KEY CLUSTERED 
(
	[event_id] ASC,
	[attendee_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_People_Speakers]    Script Date: 02/22/2010 21:57:17 ******/
ALTER TABLE [dbo].[Speakers]  WITH CHECK ADD  CONSTRAINT [FK_People_Speakers] FOREIGN KEY([person_id])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[Speakers] CHECK CONSTRAINT [FK_People_Speakers]
GO
/****** Object:  ForeignKey [FK_Locations_Events]    Script Date: 02/22/2010 21:57:17 ******/
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Locations_Events] FOREIGN KEY([location_id])
REFERENCES [dbo].[Locations] ([id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Locations_Events]
GO
/****** Object:  ForeignKey [FK_TimeSlots_Events]    Script Date: 02/22/2010 21:57:17 ******/
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_TimeSlots_Events] FOREIGN KEY([timeslot_id])
REFERENCES [dbo].[TimeSlots] ([id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_TimeSlots_Events]
GO
/****** Object:  ForeignKey [FK_Foods_Attendees]    Script Date: 02/22/2010 21:57:17 ******/
ALTER TABLE [dbo].[Attendees]  WITH CHECK ADD  CONSTRAINT [FK_Foods_Attendees] FOREIGN KEY([food_choice_id])
REFERENCES [dbo].[Foods] ([id])
GO
ALTER TABLE [dbo].[Attendees] CHECK CONSTRAINT [FK_Foods_Attendees]
GO
/****** Object:  ForeignKey [FK_People_Attendees]    Script Date: 02/22/2010 21:57:17 ******/
ALTER TABLE [dbo].[Attendees]  WITH CHECK ADD  CONSTRAINT [FK_People_Attendees] FOREIGN KEY([person_id])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[Attendees] CHECK CONSTRAINT [FK_People_Attendees]
GO
/****** Object:  ForeignKey [FK_TShirts_Attendees]    Script Date: 02/22/2010 21:57:17 ******/
ALTER TABLE [dbo].[Attendees]  WITH CHECK ADD  CONSTRAINT [FK_TShirts_Attendees] FOREIGN KEY([tshirt_id])
REFERENCES [dbo].[TShirtSizes] ([id])
GO
ALTER TABLE [dbo].[Attendees] CHECK CONSTRAINT [FK_TShirts_Attendees]
GO
/****** Object:  ForeignKey [FK_Events_EventsSpeakers]    Script Date: 02/22/2010 21:57:17 ******/
ALTER TABLE [dbo].[EventsSpeakers]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventsSpeakers] FOREIGN KEY([event_id])
REFERENCES [dbo].[Events] ([id])
GO
ALTER TABLE [dbo].[EventsSpeakers] CHECK CONSTRAINT [FK_Events_EventsSpeakers]
GO
/****** Object:  ForeignKey [FK_Speakers_EventsSpeakers]    Script Date: 02/22/2010 21:57:17 ******/
ALTER TABLE [dbo].[EventsSpeakers]  WITH CHECK ADD  CONSTRAINT [FK_Speakers_EventsSpeakers] FOREIGN KEY([speaker_id])
REFERENCES [dbo].[Speakers] ([person_id])
GO
ALTER TABLE [dbo].[EventsSpeakers] CHECK CONSTRAINT [FK_Speakers_EventsSpeakers]
GO
/****** Object:  ForeignKey [FK_Attendees_EventsAttendees]    Script Date: 02/22/2010 21:57:17 ******/
ALTER TABLE [dbo].[EventsAttendees]  WITH CHECK ADD  CONSTRAINT [FK_Attendees_EventsAttendees] FOREIGN KEY([attendee_id])
REFERENCES [dbo].[Attendees] ([person_id])
GO
ALTER TABLE [dbo].[EventsAttendees] CHECK CONSTRAINT [FK_Attendees_EventsAttendees]
GO
/****** Object:  ForeignKey [FK_Events_EventsAttendees]    Script Date: 02/22/2010 21:57:17 ******/
ALTER TABLE [dbo].[EventsAttendees]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventsAttendees] FOREIGN KEY([event_id])
REFERENCES [dbo].[Events] ([id])
GO
ALTER TABLE [dbo].[EventsAttendees] CHECK CONSTRAINT [FK_Events_EventsAttendees]
GO
