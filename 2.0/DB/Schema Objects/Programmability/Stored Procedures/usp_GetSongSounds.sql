IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetSongSounds]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[usp_GetSongSounds]
GO

create proc [dbo].[usp_GetSongSounds]( @SongId int )
as
set nocount on

select s.*
      ,srv.Address as ServerPath
      ,srv.Online as ServerOnline
      ,case
            when o.ExternalLink is not null then o.ExternalLink
            when srv.ONLINE = 1 and s.PATH is not null then srv.PREFIX + srv.ADDRESS + '/' + s.PATH
            else null
       end as ExternalLink
  from SOUND_LINK sl
 inner join SOUNDS s on s.SOUND_ID = sl.SOUND_ID
 inner join [SERVERS] srv on srv.SERVER_ID = s.SERVER_ID
   left join Orders o on o.Sound_Id = s.Sound_Id and o.Active = 'Y' and o.ExternalLink is not null
 where sl.Song_Id = @SongId
 order by s.Type

GO
