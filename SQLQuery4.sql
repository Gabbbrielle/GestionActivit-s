USE [Activities]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[GetListActivities]

SELECT	@return_value as 'Return Value'

GO
