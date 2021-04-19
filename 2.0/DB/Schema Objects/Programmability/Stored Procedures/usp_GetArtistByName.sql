IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetArtistByName]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[usp_GetArtistByName]
GO

create proc [dbo].[usp_GetArtistByName]( @ArtistName varchar(50) )
as
set nocount on

declare @ArtistId int, @name varchar(50), @aka int, @name1 varchar(50)
      
select top 1 @ArtistId = ARTIST_ID
      ,@name = NAME
      ,@aka = AKA
      ,@name1 = Name1
  from Artists
 where NAME = @ArtistName or @name1 = @ArtistName
       
if ( @aka is not null ) set @ArtistId = @aka
       
select *
  from Artists
 where Artist_Id = @ArtistId

GO
