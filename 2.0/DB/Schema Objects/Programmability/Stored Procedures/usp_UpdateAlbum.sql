IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UpdateAlbum]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[usp_UpdateAlbum]
GO

CREATE proc [dbo].[usp_UpdateAlbum]
(
 @Id int
,@ArtistId int
,@Name varchar(60)
,@LargeImage varchar(50)
,@SmallImage varchar(50)
,@Year smallint
,@Genre tinyint
,@Wanted tinyint
,@Producer varchar(50)
,@CD tinyint
,@Buy varchar(100)
,@Listen varchar(100)
,@InfoText text
,@ModifiedBy int
 )
as
set nocount on

if ( @Id is null ) begin

   insert into Albums( ARTIST_ID, NAME, LARGE_IMAGE, SMALL_IMAGE, YEAR, GENDRE, WANTED, PRODUCER, CD, BUY, LISTEN, InfoText, CreatedBy )
          values ( @ArtistId, @Name, @LargeImage, @SmallImage, @Year, @Genre, @Wanted, @Producer, @CD, @Buy, @Listen, @InfoText, @ModifiedBy )
   set @Id = scope_identity()
   
end else begin

   insert into AlbumsHistory
          select Albums.*, getdate()
            from Albums where Album_Id = @Id
            
   update Albums
      set Artist_id = @ArtistId
         ,Name = @Name
         ,Large_Image = @LargeImage
         ,Small_Image = @SmallImage
         ,YEAR = @Year
         ,GENDRE = @Genre
         ,WANTED = @Wanted
         ,PRODUCER = @Producer
         ,CD = @CD
         ,BUY = @Buy
         ,LISTEN = @Listen
         ,InfoText = @InfoText
         ,ModifiedBy = @ModifiedBy
         ,ModifiedOn = getdate()
    where Album_Id = @Id

end

select @Id as Album_Id

GO
