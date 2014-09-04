/****** Object:  Table [dbo].[CmsNews_Campaign]    Script Date: 02/25/2014 14:56:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CmsNews_Campaign](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LangGuid] [nvarchar](1000) NOT NULL,
	[Inputtitle] [nvarchar](1000) NOT NULL,
	[InputType] [int] NOT NULL,
	[IsAllowNull] [bit] NOT NULL,
	[InputName] [nvarchar](1000) NOT NULL,
	[InputValue] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


  ALTER TABLE CmsNews ADD   Specification nvarchar(MAX)
