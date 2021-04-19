IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetArtist]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[usp_GetArtist]
GO

CREATE PROCEDURE [dbo].[usp_GetArtist]( @artistId int )
as
set nocount on

select * from Artists where Artist_Id = @artistId

GO
