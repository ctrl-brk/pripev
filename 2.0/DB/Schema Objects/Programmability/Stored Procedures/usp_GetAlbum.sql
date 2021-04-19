IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetAlbum]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[usp_GetAlbum]
GO

create proc [dbo].[usp_GetAlbum]( @AlbumId int )
as
set nocount on

select al.*
      ,ar.Name as ArtistName
      ,case
          when exists (select pl.PartnerId from PartnerLink pl where pl.ProductId = al.ALBUM_ID and pl.ProductType = 'B' and pl.ActiveFlag = 'Y' ) then 'Y'
          else 'N'
       end as BuyFlag
  from Albums al
          inner join Artists ar on ar.ARTIST_ID = al.ARTIST_ID
 where al.Album_Id = @AlbumId


GO
