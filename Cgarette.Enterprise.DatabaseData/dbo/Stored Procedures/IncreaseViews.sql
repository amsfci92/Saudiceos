-- =============================================
-- Author:		Ali-Shehata - ali.shehata92@hotmail.com
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[IncreaseViews] 
	-- Add the parameters for the stored procedure here
	@id int = 0,
	@amount int = 0, 
	@entity int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 
		IF @entity = 0 
			UPDATE CEO  SET  Views = Views + @amount WHERE Id = @Id;
		IF @entity = 1 
			UPDATE News  SET  Views = Views + @amount WHERE Id = @Id;

END
