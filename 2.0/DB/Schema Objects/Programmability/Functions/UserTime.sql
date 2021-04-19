IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserTime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[UserTime]
GO

CREATE FUNCTION [dbo].[UserTime]( @LocalTime datetime, @UserId int )
returns datetime
as
begin

declare @ut datetime

select @ut = dateadd( mi, isnull( u.TimeOffset, 180 ) + 420, @LocalTime )
  from WebUsers u
 where u.UserId = @UserId

return( @ut )

end

GO
