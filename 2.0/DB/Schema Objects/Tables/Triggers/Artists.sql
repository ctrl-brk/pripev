IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[DeleteArtist]'))
DROP TRIGGER [dbo].[DeleteArtist]
GO

CREATE TRIGGER [dbo].[DeleteArtist] ON [dbo].[ARTISTS] FOR DELETE
AS
delete from ARTISTS where AKA in (select ARTIST_ID from deleted)
delete from ALBUMS where ARTIST_ID in (select ARTIST_ID from deleted where AKA is null)

GO
