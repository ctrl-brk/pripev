IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ArtistNames]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[ArtistNames]
GO

CREATE FUNCTION [dbo].[ArtistNames]( @ArtistId int )
returns
@ArtistNames table( ArtistName varchar(255) )
as
begin

   declare @Name varchar(255), @AltName varchar(255)
   declare @i int, @s varchar(255)

   select @Name = Name, @AltName = Name1 from Artists where Artist_Id = @ArtistId

   insert into @ArtistNames( ArtistName ) values( @Name )

   if ( @AltName is not null ) begin

      set @i = charindex( '|', @AltName )
      if ( @i = 0 ) begin
		 insert into @ArtistNames( ArtistName ) values( @AltName )
      end else begin
         while( @i > 0 ) begin
            set @s = left( @AltName, @i-1 )
			insert into @ArtistNames( ArtistName ) values( @s )
            set @AltName = right( @AltName, len( @AltName ) - @i )
            set @i = charindex( '|', @AltName )
         end
         insert into @ArtistNames( ArtistName ) values( @AltName )
      end

   end

   insert into @ArtistNames
      select Name from Artists where AKA = @ArtistId

   return
end

GO
