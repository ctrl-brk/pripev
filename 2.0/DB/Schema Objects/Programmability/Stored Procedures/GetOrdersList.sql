IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetOrdersList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetOrdersList]
GO

CREATE proc [dbo].[GetOrdersList]
as
set nocount on

declare @OrderId int, @UserId int, @Date datetime, @Name varchar(50), @Email varchar(50), @Artist varchar(100), @Album varchar(100), @Song varchar(100),
        @Status tinyint, @ServerId int, @Path varchar(255), @SoundId int, @ExternalLink varchar(255), @OutsourceFlag char(1), @DirectFlag char(1)

create table #orders ( ORDER_ID int, UserId int, Name varchar(50), Email varchar(50),
                       Artist varchar(100), Album varchar(100), Song varchar(100), Status tinyint,
                       [Path] varchar(255), Prefix varchar(10), Address varchar(100), Port smallint,
                       UserName varchar(50), Password varchar(50), Online tinyint, Date datetime,
                       ExternalLink varchar(255), OutsourceFlag char(1), DirectFlag char(1) )

declare cSel cursor for
   select o.ORDER_ID, o.UserId, o.DATE, u.Name, u.Email, o.ARTIST, o.ALBUM, o.SONG, o.STATUS, o.SERVER_ID, o.PATH, o.SOUND_ID, o.ExternalLink, o.OutsourceFlag, o.DirectFlag
     from ORDERS o
            left join WebUsers u on u.UserId = o.UserId
    where isnull( o.NOTIFY, 1 ) = 0
      and o.Active = 'Y'

open cSel
fetch next from cSel into @OrderId, @UserId, @Date, @Name, @Email, @Artist, @Album, @Song, @Status, @ServerId, @Path, @SoundId, @ExternalLink, @OutsourceFlag, @DirectFlag

while ( @@fetch_status = 0 ) begin

   if( @SoundId is not null or @ExternalLink is not null ) set @Status = 1

   if( @SoundId is not null and @OutsourceFlag <> 'Y' ) begin

      select @ServerId = SERVER_ID, @Path = [PATH]
        from SOUNDS
       where SOUND_ID = @SoundId

      select @Album = al.[NAME]
        from ALBUMS al
				inner join SONGS s on s.ALBUM_ID = al.ALBUM_ID				
                inner join SOUND_LINK sl on sl.SONG_ID = s.SONG_ID
       where sl.SOUND_ID = @SoundId

   end

   insert into #orders
      select @OrderId,
             @UserId,
             @Name,
             @Email,
             @Artist,
             @Album,
             @Song,
             @Status,
             @Path,
             s.PREFIX,
             s.ADDRESS,
             s.PORT,
             s.USERNAME,
             s.PASSWORD,
             s.ONLINE,
             dbo.UserTime( @Date, @UserId ),
             @ExternalLink,
             @OutsourceFlag,
             @DirectFlag
        from SERVERS s
       where s.SERVER_ID = @ServerId

   fetch next from cSel into @OrderId, @UserId, @Date, @Name, @Email, @Artist, @Album, @Song, @Status, @ServerId, @Path, @SoundId, @ExternalLink, @OutsourceFlag, @DirectFlag

end

close cSel
deallocate cSel

select * from #orders order by Date desc
