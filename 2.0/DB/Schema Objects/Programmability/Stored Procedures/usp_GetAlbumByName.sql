IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetAlbumByName]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[usp_GetAlbumByName]
GO

create proc [dbo].[usp_GetAlbumByName]
(
 @ArtistId int
,@AlbumName varchar(60)
 )
as
set nocount on

declare @AlbumId int

select @AlbumId = Album_Id
  from Albums
 where Artist_Id = @ArtistId
   and NAME = @AlbumName

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
