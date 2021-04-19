IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateAlbumSoundPath]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateAlbumSoundPath]
GO

CREATE proc [dbo].[UpdateAlbumSoundPath]
(
 @SoundId int
,@Path varchar(255)
)
as
set nocount on

update ALBUMS
   set RootPath = @Path
 where ALBUM_ID in( select ALBUM_ID from SONGS where SONG_ID in( select SONG_ID from SOUND_LINK where SOUND_ID = @SoundId ) )

GO
