IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetUserOrders]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetUserOrders]
GO

CREATE proc [dbo].[GetUserOrders]
(
 @UserId int
,@ActiveFlag char(1) = null
,@From datetime = null
,@To datetime = null
,@OtherUsersFlag char(1) = 'N'
,@History int = null
)
as
set nocount on

if ( @History is not null ) set @ActiveFlag = null
set @History = isnull( @History, 36500 )

if ( @To is null ) set @To = getdate()
if ( @From is null ) set @From = dateadd( dd, -(@History), getdate() )

declare @OrderId int, @Date datetime, @ArtistName varchar(100), @AlbumName varchar(100),
        @SongName varchar(100), @Status tinyint, @ServerId int, @Path varchar(255), @SoundId int, @ExternalLink varchar(255), @DirectFlag char(1), @Active char(1)

create table #orders ( OrderId int, Date datetime, ArtistName varchar(100), AlbumName varchar(100), SongName varchar(100),
                       Status tinyint, Path varchar(255), Prefix varchar(10), Address varchar(100), Port smallint,
                       AccessName varchar(50), AssessPassword varchar(50), Online tinyint, ExternalLink varchar(255),
                       DirectFlag char(1), Active char(1) )

if ( @OtherUsersFlag <> 'Y' ) begin
   declare cSel cursor for
      select ORDER_ID, dbo.UserTime( DATE, @UserId ), ARTIST, ALBUM, SONG, STATUS, SERVER_ID, PATH, SOUND_ID, ExternalLink, DirectFlag, Active
        from ORDERS
       where UserId = @UserId
         and Active = isnull( @ActiveFlag, Active )
         and [DATE] between @From and @To
end else begin
   declare cSel cursor for
      select ORDER_ID, dbo.UserTime( DATE, @UserId ), ARTIST, ALBUM, SONG, STATUS, SERVER_ID, PATH, SOUND_ID, ExternalLink, DirectFlag, Active
        from ORDERS
       where UserId <> @UserId
         and Active = 'Y'
end

open cSel
fetch next from cSel into @OrderId, @Date, @ArtistName, @AlbumName, @SongName, @Status, @ServerId, @Path, @SoundId, @ExternalLink, @DirectFlag, @Active

while ( @@fetch_status = 0 ) begin
   
   if( @SoundId is not null ) begin

      select @Status=1, @ServerId=SERVER_ID, @Path=PATH
        from SOUNDS
       where SOUND_ID = @SoundId

      select @AlbumName=AL.NAME
        from ALBUMS AL, SOUND_LINK SL, SONGS S
       where SL.SOUND_ID=@SoundId and S.SONG_ID = SL.SONG_ID and AL.ALBUM_ID = S.ALBUM_ID
   end

   insert into #orders
      select @OrderId,
             @Date,
             @ArtistName,
             @AlbumName,
             @SongName,
             @Status,
             @Path,
             S.PREFIX,
             S.ADDRESS,
             S.PORT,
             S.USERNAME,
             S.PASSWORD,
             S.ONLINE,
             @ExternalLink,
             @DirectFlag,
             @Active
        from SERVERS S
       where S.SERVER_ID = @ServerId

   fetch next from cSel into @OrderId, @Date, @ArtistName, @AlbumName, @SongName, @Status, @ServerId, @Path, @SoundId, @ExternalLink, @DirectFlag, @Active

end

close cSel
deallocate cSel

select * from #orders order by Date desc

GO
