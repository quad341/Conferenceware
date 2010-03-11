-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jim Wordelman
-- Create date: 2010-03-10
-- Description:	Trigger for keeping integrity of pages on delete
-- =============================================
CREATE TRIGGER DeleteClean 
   ON  Conferenceware.dbo.Pages 
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- loops are slow, but this is more readable and is based on the assumption
	-- that you have a small dataset. in actuality, this loop will probably
	-- only execute once making performance just fine
	DECLARE @parent_id int, @grandparent_id int
	
	DECLARE result_cursor CURSOR FOR
	SELECT id,parent_id FROM deleted
	
	OPEN result_cursor
	
	FETCH NEXT FROM result_cursor
	INTO @parent_id,@grandparent_id
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE Pages
		SET parent_id = @grandparent_id
		WHERE parent_id = @parent_id;
		
		FETCH NEXT FROM result_cursor
		INTO @parent_id,@grandparent_id
	END
	
	CLOSE result_cursor
	DEALLOCATE result_cursor

END
GO
