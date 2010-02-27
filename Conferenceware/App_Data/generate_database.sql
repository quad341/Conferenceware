USE [Conferenceware]
GO
/****** Object:  Table [dbo].[People]    Script Date: 02/27/2010 14:16:08 ******/
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
/****** Object:  Table [dbo].[Locations]    Script Date: 02/27/2010 14:16:08 ******/
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
/****** Object:  Table [dbo].[Foods]    Script Date: 02/27/2010 14:16:08 ******/
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
/****** Object:  Table [dbo].[TShirtSizes]    Script Date: 02/27/2010 14:16:08 ******/
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
/****** Object:  Table [dbo].[TimeSlots]    Script Date: 02/27/2010 14:16:08 ******/
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
/****** Object:  Table [dbo].[Staff]    Script Date: 02/27/2010 14:16:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[person_id] [int] NOT NULL,
	[auth_name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[person_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Speakers]    Script Date: 02/27/2010 14:16:08 ******/
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
/****** Object:  Table [dbo].[Events]    Script Date: 02/27/2010 14:16:08 ******/
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
	[is_visible] [bit] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendees]    Script Date: 02/27/2010 14:16:08 ******/
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
/****** Object:  Table [dbo].[Volunteers]    Script Date: 02/27/2010 14:16:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Volunteers](
	[person_id] [int] NOT NULL,
	[is_video_trained] [bit] NOT NULL,
 CONSTRAINT [PK_Volunteers] PRIMARY KEY CLUSTERED 
(
	[person_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VolunteerTimeSlots]    Script Date: 02/27/2010 14:16:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerTimeSlots](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[volunteer_id] [int] NOT NULL,
	[timeslot_id] [int] NOT NULL,
	[is_video] [bit] NOT NULL,
	[is_scheduled] [bit] NOT NULL,
	[is_confirmed] [bit] NOT NULL,
 CONSTRAINT [PK_VolunteerTimeSlots] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MechManiaTeams]    Script Date: 02/27/2010 14:16:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MechManiaTeams](
	[id] [int] NOT NULL,
	[team_name] [nvarchar](255) NOT NULL,
	[member1_id] [int] NOT NULL,
	[member2_id] [int] NOT NULL,
	[member3_id] [int] NOT NULL,
	[account_name] [varchar](255) NOT NULL,
	[account_password] [varchar](255) NOT NULL,
 CONSTRAINT [PK_MechManiaTeams] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventsSpeakers]    Script Date: 02/27/2010 14:16:08 ******/
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
/****** Object:  Table [dbo].[EventsAttendees]    Script Date: 02/27/2010 14:16:08 ******/
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
/****** Object:  Default [DF_Events_is_visible]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[Events] ADD  CONSTRAINT [DF_Events_is_visible]  DEFAULT ((1)) FOR [is_visible]
GO
/****** Object:  Default [DF_VolunteerTimeSlots_is_video]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[VolunteerTimeSlots] ADD  CONSTRAINT [DF_VolunteerTimeSlots_is_video]  DEFAULT ((0)) FOR [is_video]
GO
/****** Object:  Default [DF_VolunteerTimeSlots_is_scheduled]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[VolunteerTimeSlots] ADD  CONSTRAINT [DF_VolunteerTimeSlots_is_scheduled]  DEFAULT ((0)) FOR [is_scheduled]
GO
/****** Object:  Default [DF_VolunteerTimeSlots_is_confirmed]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[VolunteerTimeSlots] ADD  CONSTRAINT [DF_VolunteerTimeSlots_is_confirmed]  DEFAULT ((0)) FOR [is_confirmed]
GO
/****** Object:  ForeignKey [FK_Foods_Attendees]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[Attendees]  WITH CHECK ADD  CONSTRAINT [FK_Foods_Attendees] FOREIGN KEY([food_choice_id])
REFERENCES [dbo].[Foods] ([id])
GO
ALTER TABLE [dbo].[Attendees] CHECK CONSTRAINT [FK_Foods_Attendees]
GO
/****** Object:  ForeignKey [FK_People_Attendees]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[Attendees]  WITH CHECK ADD  CONSTRAINT [FK_People_Attendees] FOREIGN KEY([person_id])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[Attendees] CHECK CONSTRAINT [FK_People_Attendees]
GO
/****** Object:  ForeignKey [FK_TShirts_Attendees]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[Attendees]  WITH CHECK ADD  CONSTRAINT [FK_TShirts_Attendees] FOREIGN KEY([tshirt_id])
REFERENCES [dbo].[TShirtSizes] ([id])
GO
ALTER TABLE [dbo].[Attendees] CHECK CONSTRAINT [FK_TShirts_Attendees]
GO
/****** Object:  ForeignKey [FK_Locations_Events]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Locations_Events] FOREIGN KEY([location_id])
REFERENCES [dbo].[Locations] ([id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Locations_Events]
GO
/****** Object:  ForeignKey [FK_TimeSlots_Events]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_TimeSlots_Events] FOREIGN KEY([timeslot_id])
REFERENCES [dbo].[TimeSlots] ([id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_TimeSlots_Events]
GO
/****** Object:  ForeignKey [FK_Attendees_EventsAttendees]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[EventsAttendees]  WITH CHECK ADD  CONSTRAINT [FK_Attendees_EventsAttendees] FOREIGN KEY([attendee_id])
REFERENCES [dbo].[Attendees] ([person_id])
GO
ALTER TABLE [dbo].[EventsAttendees] CHECK CONSTRAINT [FK_Attendees_EventsAttendees]
GO
/****** Object:  ForeignKey [FK_Events_EventsAttendees]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[EventsAttendees]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventsAttendees] FOREIGN KEY([event_id])
REFERENCES [dbo].[Events] ([id])
GO
ALTER TABLE [dbo].[EventsAttendees] CHECK CONSTRAINT [FK_Events_EventsAttendees]
GO
/****** Object:  ForeignKey [FK_Events_EventsSpeakers]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[EventsSpeakers]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventsSpeakers] FOREIGN KEY([event_id])
REFERENCES [dbo].[Events] ([id])
GO
ALTER TABLE [dbo].[EventsSpeakers] CHECK CONSTRAINT [FK_Events_EventsSpeakers]
GO
/****** Object:  ForeignKey [FK_Speakers_EventsSpeakers]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[EventsSpeakers]  WITH CHECK ADD  CONSTRAINT [FK_Speakers_EventsSpeakers] FOREIGN KEY([speaker_id])
REFERENCES [dbo].[Speakers] ([person_id])
GO
ALTER TABLE [dbo].[EventsSpeakers] CHECK CONSTRAINT [FK_Speakers_EventsSpeakers]
GO
/****** Object:  ForeignKey [FK_Attendees_MechManiaTeams1]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[MechManiaTeams]  WITH CHECK ADD  CONSTRAINT [FK_Attendees_MechManiaTeams1] FOREIGN KEY([member1_id])
REFERENCES [dbo].[Attendees] ([person_id])
GO
ALTER TABLE [dbo].[MechManiaTeams] CHECK CONSTRAINT [FK_Attendees_MechManiaTeams1]
GO
/****** Object:  ForeignKey [FK_Attendees_MechManiaTeams2]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[MechManiaTeams]  WITH CHECK ADD  CONSTRAINT [FK_Attendees_MechManiaTeams2] FOREIGN KEY([member2_id])
REFERENCES [dbo].[Attendees] ([person_id])
GO
ALTER TABLE [dbo].[MechManiaTeams] CHECK CONSTRAINT [FK_Attendees_MechManiaTeams2]
GO
/****** Object:  ForeignKey [FK_Attendees_MechManiaTeams3]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[MechManiaTeams]  WITH CHECK ADD  CONSTRAINT [FK_Attendees_MechManiaTeams3] FOREIGN KEY([member3_id])
REFERENCES [dbo].[Attendees] ([person_id])
GO
ALTER TABLE [dbo].[MechManiaTeams] CHECK CONSTRAINT [FK_Attendees_MechManiaTeams3]
GO
/****** Object:  ForeignKey [FK_People_Speakers]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[Speakers]  WITH CHECK ADD  CONSTRAINT [FK_People_Speakers] FOREIGN KEY([person_id])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[Speakers] CHECK CONSTRAINT [FK_People_Speakers]
GO
/****** Object:  ForeignKey [FK_Staff_People]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_People] FOREIGN KEY([person_id])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_People]
GO
/****** Object:  ForeignKey [FK_Volunteers_People]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[Volunteers]  WITH CHECK ADD  CONSTRAINT [FK_Volunteers_People] FOREIGN KEY([person_id])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[Volunteers] CHECK CONSTRAINT [FK_Volunteers_People]
GO
/****** Object:  ForeignKey [FK_VolunteerTimeSlots_TimeSlots]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[VolunteerTimeSlots]  WITH CHECK ADD  CONSTRAINT [FK_VolunteerTimeSlots_TimeSlots] FOREIGN KEY([timeslot_id])
REFERENCES [dbo].[TimeSlots] ([id])
GO
ALTER TABLE [dbo].[VolunteerTimeSlots] CHECK CONSTRAINT [FK_VolunteerTimeSlots_TimeSlots]
GO
/****** Object:  ForeignKey [FK_VolunteerTimeSlots_Volunteers]    Script Date: 02/27/2010 14:16:08 ******/
ALTER TABLE [dbo].[VolunteerTimeSlots]  WITH CHECK ADD  CONSTRAINT [FK_VolunteerTimeSlots_Volunteers] FOREIGN KEY([volunteer_id])
REFERENCES [dbo].[Volunteers] ([person_id])
GO
ALTER TABLE [dbo].[VolunteerTimeSlots] CHECK CONSTRAINT [FK_VolunteerTimeSlots_Volunteers]
GO
