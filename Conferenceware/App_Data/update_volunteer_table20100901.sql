USE [Conferenceware]
GO

/* get rid of stuff that will complain */
DELETE FROM [dbo].[VolunteersVolunteerTimeSlots]
GO
DELETE FROM [dbo].[Volunteers]
GO

/* add columns */
ALTER TABLE [dbo].[Volunteers] ADD
	[tshirt_id] [int] NOT NULL,
	[food_choice_id] [int] NOT NULL
GO
/* add constraints */
/****** Object:  ForeignKey [FK_Volunteers_Foods]    Script Date: 09/01/2010 23:21:50 ******/
ALTER TABLE [dbo].[Volunteers]  WITH CHECK ADD  CONSTRAINT [FK_Volunteers_Foods] FOREIGN KEY([food_choice_id])
REFERENCES [dbo].[Foods] ([id])
GO
ALTER TABLE [dbo].[Volunteers] CHECK CONSTRAINT [FK_Volunteers_Foods]
GO
/****** Object:  ForeignKey [FK_Volunteers_People]    Script Date: 09/01/2010 23:21:50 ******/
ALTER TABLE [dbo].[Volunteers]  WITH CHECK ADD  CONSTRAINT [FK_Volunteers_People] FOREIGN KEY([person_id])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[Volunteers] CHECK CONSTRAINT [FK_Volunteers_People]
GO
/****** Object:  ForeignKey [FK_Volunteers_TShirtSizes]    Script Date: 09/01/2010 23:21:50 ******/
ALTER TABLE [dbo].[Volunteers]  WITH CHECK ADD  CONSTRAINT [FK_Volunteers_TShirtSizes] FOREIGN KEY([tshirt_id])
REFERENCES [dbo].[TShirtSizes] ([id])
GO
ALTER TABLE [dbo].[Volunteers] CHECK CONSTRAINT [FK_Volunteers_TShirtSizes]
GO
