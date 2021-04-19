IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReverseArtist]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[ReverseArtist]
GO

CREATE FUNCTION [dbo].[ReverseArtist]( @Name varchar(50) )
returns varchar(50)
as
begin

declare @i int, @l int, @s1 varchar(50), @s2 varchar(50), @s varchar(50)

set @s = @Name

set @i = charindex( ' ', @Name )
set @l = len( @Name )

if ( @i > 0 ) begin
   set @s1 = left( @Name, @i )
   set @s2 = right( @Name, @l - @i )
   set @s = @s2 + ' ' + @s1 
end

return( @s )

end

GO
