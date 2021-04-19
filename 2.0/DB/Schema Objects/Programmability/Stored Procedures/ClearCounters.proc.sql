IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClearCounters]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ClearCounters]
GO

CREATE Procedure [dbo].[ClearCounters]
As

delete
  from counter
 where type <> 'ARTIST'
   and type <> 'ALBUM'
   and type <> 'SONG'
   and DATE < dateadd(mm,-1,getdate())

delete from counter
 where type = 'SONG'
   and ID not in (select SONG_ID from SONGS)

delete from counter
 where type = 'ALBUM'
   and ID not in (select ALBUM_ID from ALBUMS)
   
delete from counter
 where type = 'ARTIST'
   and ID not in (select ARTIST_ID from ARTISTS)

GO
