IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OzonArtist]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[OzonArtist]
GO

CREATE FUNCTION [dbo].[OzonArtist](	@Artist varchar(255) )
RETURNS varchar(255)
AS
BEGIN

declare @i int, @s varchar(255)

set @s = null
set @i = charindex( '. ', @Artist )

if ( @i > 0 ) begin
   set @s = left( @Artist, @i-1 )
end

return( @s )


END

GO
