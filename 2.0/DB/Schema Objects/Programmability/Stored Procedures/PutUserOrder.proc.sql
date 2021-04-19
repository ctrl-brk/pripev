IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PutUserOrder]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PutUserOrder]
GO

CREATE PROCEDURE [dbo].[PutUserOrder]
(
 @UserId int
,@Artist varchar(255) = null
,@Album varchar(255) = null
,@Song varchar(255) = null
,@IP varchar(20)
,@Comments varchar(255) = null
,@DirectFlag char(1) = 'N'
,@ExternalLink varchar(255) = null
)
as
set nocount on

declare @Cnt int, @FilesPerDay int, @ArtistId int, @ArtistName varchar(255), @AlbumId int, @SongId int, @SoundId int, @Msg varchar(255)

select @FilesPerDay = FilesPerDay from WebUsers where UserId = @UserId

if ( @FilesPerDay is not null )
   select @Cnt = count( ORDER_ID )
     from ORDERS
    where UserId = @UserId
      and ( Active = 'Y' or DirectFlag = 'Y' )
      and DATE > dateadd( dd, -1, getdate() )

if ( @Cnt is not null and @Cnt >= @FilesPerDay ) begin
   set @Msg = 'Вы превысили лимит розыска. ' + convert( varchar(10), @FilesPerDay ) + ' файл(а,ов) за 24 часа.'
   goto EXIT_SP
end

if ( @DirectFlag = 'Y' ) begin

   if ( exists( select ORDER_ID from ORDERS where UserId = @UserId and ExternalLink = @ExternalLink ) ) begin
      set @Msg = 'Dup'
   end

   insert into ORDERS( IP, UserId, ExternalLink, DirectFlag, NOTIFY, ModifiedBy, ModifiedOn )
      values( @IP, @UserId, @ExternalLink, @DirectFlag, 1, @UserId, getdate() )

   goto EXIT_SP
   
end

select @ArtistId = case
                      when ar.AKA is null then ar.ARTIST_ID
                      else ar.AKA
                   end
 from ARTISTS ar
where ar.NAME= @Artist

if ( @ArtistId is null ) begin
   set @Msg = 'Указанный исполнитель не найден.<br>Проверьте имя или воспользуйтесь кнопками выбора'
   goto EXIT_SP
end

select @AlbumId = al.ALBUM_ID, @ArtistName = ar.NAME
  from ALBUMS al
          inner join ARTISTS ar on ar.ARTIST_ID = al.ARTIST_ID
 where al.NAME = @Album
   and (
        al.ARTIST_ID = @ArtistId
        or @ArtistId in ( select lnk.ArtistId from AlbumLink lnk where lnk.AlbumId = al.ALBUM_ID )
       )

if ( @AlbumId is null ) begin
   set @Msg = 'Указанный альбом не найден.<br>Проверьте имя или воспользуйтесь кнопками выбора'
   goto EXIT_SP
end

if ( exists( select ORDER_ID from ORDERS where UserId = @UserId and ARTIST = @Artist and ALBUM = @Album and SONG = @Song ) ) begin
   set @Msg = 'Dup'
end

select @SongId = s.SONG_ID
  from SONGS s
          inner join ALBUMS al on al.ALBUM_ID = s.ALBUM_ID
          inner join ARTISTS ar on ar.ARTIST_ID = al.ARTIST_ID
 where s.NAME = @Song
   and s.ALBUM_ID = @AlbumId
   and (
        al.ARTIST_ID = @ArtistId
        or @ArtistId in ( select lnk.ArtistId from AlbumLink lnk where lnk.AlbumId = al.ALBUM_ID )
       )
   and (   al.CD = 1
        or exists( select sl.SOUND_ID
                     from SOUND_LINK sl
                             inner join SOUNDS sd on sd.SOUND_ID = sl.SOUND_ID
                    where sl.SONG_ID = s.SONG_ID
                      and ( SD.TYPE='mp3' or SD.TYPE='wma' or SD.TYPE='ogg' ) )
       )

if ( @SongId is null ) begin
   set @Msg = 'Указанная композиция либо не найдена вообще, либо по ней нет информации.<br>Проверьте название или воспользуйтесь кнопками выбора'
   goto EXIT_SP
end

insert into ORDERS( ARTIST, ALBUM, SONG, SongId, IP, UserId, Comments )
   values( @ArtistName, @Album, @Song, @SongId, @IP, @UserId, @Comments )

EXIT_SP:

select @Msg as Msg

GO
