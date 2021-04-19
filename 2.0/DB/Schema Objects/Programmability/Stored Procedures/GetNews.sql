IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetNews]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetNews]
GO

CREATE PROCEDURE [dbo].[GetNews]( @Type varchar(20) = null, @Days int )
as
set nocount on

declare @MinDate datetime, @Texts int, @Albums int, @Artists int, @Sounds int

set @MinDate = dateadd( d, -(@Days), getdate() )

if ( @Type is null ) begin

   select @Artists = count(ARTIST_ID)
     from ARTISTS
    where ADDED >= @MinDate

   select @Albums = count(ALBUM_ID)
     from ALBUMS
    where ADDED >= @MinDate

   select @Texts = count(TEXT_ID)
     from TEXTS
    where ADDED >= @MinDate

   select @Sounds = count(SOUND_ID)
     from SOUNDS
    where ADDED >= @MinDate

   select @Artists as Artists, @Albums as Albums, @Texts as Texts, @Sounds as Sounds

end else begin

   if ( @Type = 'Artist' )
      select * from ARTISTS where ADDED >= @MinDate order by NAME

   if ( @Type = 'Album' )
      select al.ALBUM_ID
            ,al.ARTIST_ID
            ,al.NAME as AlbumName
            ,ar.NAME as ArtistName
       from ALBUMS al
               inner join ARTISTS ar on ar.ARTIST_ID = al.ARTIST_ID
      where al.ADDED >= @MinDate
      order by al.NAME

   if ( @Type = 'Text' )
      select s.SONG_ID
            ,s.NAME as SongName
            ,ar.ARTIST_ID
            ,ar.NAME as ArtistName
            ,al.ALBUM_ID
            ,al.NAME as AlbumName
        from SONGS s
                inner join ALBUMS al on al.ALBUM_ID = s.ALBUM_ID
                inner join ARTISTS ar on ar.ARTIST_ID = al.ARTIST_ID
				inner join TEXT_LINK tl on tl.SONG_ID = s.SONG_ID
                inner join TEXTS t on t.TEXT_ID = tl.TEXT_ID
       where t.ADDED >= @MinDate
       order by s.NAME, al.NAME, ar.NAME

   if ( @Type = 'Sound' )
      select s.SONG_ID, s.ALBUM_ID, al.NAME as AlbumName, ar.ARTIST_ID, ar.NAME as ArtistName
        from SONGS s
               inner join SOUND_LINK sl on sl.SONG_ID = s.SONG_ID
				   inner join SOUNDS sd on sd.SOUND_ID = sl.SOUND_ID
				   inner join ALBUMS al on al.ALBUM_ID = s.ALBUM_ID
				   inner join ARTISTS ar on ar.ARTIST_ID = al.ARTIST_ID
       where sd.ADDED >= @MinDate
       order by sd.SOUND_ID

end

GO
