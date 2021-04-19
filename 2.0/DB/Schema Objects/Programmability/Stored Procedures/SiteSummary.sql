IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SiteSummary]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SiteSummary]
GO

CREATE proc [dbo].[SiteSummary]
as
set nocount on

declare @nArtists int,
        @nAlbums int,
        @nTexts int,
        @nChords int,
        @nMP3Files int,
        @nMP3Online int,
        @nMid int,
        @nKar int,
        @nCD int

select @nArtists=count(*) from ARTISTS with (nolock)
select @nAlbums=count(*) from ALBUMS  with (nolock) where YEAR <> 20000
select @nTexts=count(*) from TEXTS with (nolock)
select @nChords=count(*) from TEXTS with (nolock) where CHORDS=1

select @nMP3Files=sum(MP3) from ARTISTS with (nolock) where AKA is null
select @nMP3Online=sum(MP3ONLINE) from ARTISTS with (nolock) where AKA is null
select @nMid=count(*) from SOUNDS with (nolock) where TYPE='mid'
select @nKar=count(*) from SOUNDS with (nolock) where TYPE='kar'
select @nCD=count(*) from ALBUMS with (nolock) where CD=1

select @nArtists as Artists,
       @nAlbums as Albums,
       @nTexts as Texts,
       @nChords as Chords,
       @nMP3Files as MP3All,
       @nMP3Online as MP3Online,
       @nMid as Midi,
       @nKar as Karaoke,
       @nCD as CDs

GO
