IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetArtistList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetArtistList]
GO

CREATE proc [dbo].[GetArtistList]
(
 @Letter char(1) = null
,@CMS char(1) = 'N'
)
as
set nocount on

declare @MinLetter char(1), @MaxLetter char(1)

if ( @Letter = 'L' ) select @MinLetter = 'A', @MaxLetter = 'Z'
if ( @Letter = '1' and @MinLetter is null ) select @MinLetter = '0', @MaxLetter = '9'
if ( @Letter is not null  and @MinLetter is null ) select @MinLetter = @Letter, @MaxLetter = @Letter
if ( @MinLetter is null ) select @MinLetter = '0', @MaxLetter = 'я'

--if ( @CMS <> 'Y' ) begin

   select *
         ,'N' as NewFlag
     from Artists
    where Letter between @MinLetter and @MaxLetter
    order by Name  
/*
end else begin

   select top 0 *
     into #tmp
     from Artists
     
   alter table #tmp add NewFlag char(1)
   alter table #tmp alter column ARTIST_ID drop identity
   
   insert into #tmp
      select *
            ,'N' as NewFlag
        from Artists
       where Letter between @MinLetter and @MaxLetter
       order by Name  

   insert into #tmp( ARTIST_ID, NAME, NewFlag )
      select distinct NewArtistId, Name, 'Y'
        from ArtistUpdate
       where NewArtistId is not null
         and Name is not null
         and Status in ('N','W')
         and left( Name, 1 ) between @MinLetter and @MaxLetter

   select * from #tmp order by Name
   
end
*/

GO

