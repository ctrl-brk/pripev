IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UpdateArtist]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[usp_UpdateArtist]
GO

CREATE proc [dbo].[usp_UpdateArtist]
(
  @Id int = null
 ,@Letter char(1)
 ,@Name varchar(50)
 ,@Name1 varchar(50)
 ,@Image varchar(20)
 ,@InfoText text
 ,@LinksText text
 ,@AKA int
 ,@ModifiedBy int
 )
as
set nocount on

if ( @Id is null ) begin

   insert into Artists( Letter, Name, Name1, Image, InfoText, LinksText, AKA, CreatedBy )
          values ( @Letter, @Name, @Name1, @Image, @InfoText, @LinksText, @AKA, @ModifiedBy )
   set @Id = scope_identity()
   
end else begin

   insert into ArtistsHistory
          select Artists.*, getdate()
            from Artists where Artist_Id = @Id
            
   update Artists
      set Letter = @Letter
         ,Name = @Name
         ,Name1 = @Name1
         ,Image = @Image
         ,InfoText = @InfoText
         ,LinksText = @LinksText
         ,AKA = @AKA
         ,ModifiedBy = @ModifiedBy
         ,ModifiedOn = getdate()
    where Artist_Id = @Id

end

select @Id as Artist_Id

GO
