IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetSound]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_GetSound]
GO

create proc [dbo].[usp_GetSound]( @SoundId int )
as
set nocount on

select s.*
      ,srv.Address as ServerPath
      ,srv.Online as ServerOnline
      ,case
            when o.ExternalLink is not null then o.ExternalLink
            when srv.ONLINE = 1 then srv.ADDRESS + '/' + s.PATH
            else null
       end as ExternalLink
  from SOUNDS s
 inner join SERVERS srv on srv.SERVER_ID = s.SERVER_ID
  left join Orders o on o.Sound_Id = s.Sound_Id and o.Active = 'Y' and o.ExternalLink is not null
 where s.Sound_Id = @SoundId

GO
