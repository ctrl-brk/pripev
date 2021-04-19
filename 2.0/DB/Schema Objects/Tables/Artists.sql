IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ARTISTS]') AND type in (N'U'))
return
GO

CREATE TABLE [dbo].[ARTISTS](
	[ARTIST_ID] [int] IDENTITY(1,1) NOT NULL,
	[LETTER] [char](1) NOT NULL,
	[NAME] [varchar](50) NOT NULL,
	[Name1] [varchar](50) NULL,
	[IMAGE] [varchar](20) NULL,
	[INFO] [varchar](20) NULL,
	[LINKS] [varchar](20) NULL,
	[ADDED] [datetime] NOT NULL,
	[AKA] [int] NULL,
	[ALBUMS] [tinyint] NOT NULL,
	[CD] [tinyint] NOT NULL,
	[SONGS] [int] NOT NULL,
	[TEXTS] [int] NOT NULL,
	[CHORDS] [int] NOT NULL,
	[MP3] [int] NOT NULL,
	[MP3ONLINE] [int] NOT NULL,
	[MID] [int] NOT NULL,
	[KAR] [int] NOT NULL,
	[MOV] [int] NOT NULL,
	[Status] [char](1) NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[ListFlag] [char](1) NOT NULL,
	[DetailsFlag] [char](1) NOT NULL,
	[InfoText] [text] NULL,
	[LinksText] [text] NULL,
 CONSTRAINT [PK_ARTISTS] PRIMARY KEY NONCLUSTERED 
(
	[ARTIST_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

