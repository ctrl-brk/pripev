IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MSK]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[MSK]
GO

CREATE function [dbo].[MSK] (@Date datetime) returns datetime
as
begin

select @Date = dateadd( hh, 10, @Date )
return( @Date )

end

GO
