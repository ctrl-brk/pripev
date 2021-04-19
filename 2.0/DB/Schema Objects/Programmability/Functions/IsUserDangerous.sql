IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsUserDangerous]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[IsUserDangerous]
GO

USE [Pripev]
GO

CREATE FUNCTION [dbo].[IsUserDangerous](@sIP [nvarchar](20), @sEmail [nvarchar](100))
RETURNS [nvarchar](4000) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SQLServer].[UserDefinedFunctions].[IsUserDangerous]
GO
