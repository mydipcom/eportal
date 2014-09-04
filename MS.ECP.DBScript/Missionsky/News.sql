IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('CmsNews')) drop table CmsNews
GO
CREATE table CmsNews (
	ID int identity,  -----id
	Guid nvarchar(1000) not null,
	LangGuid nvarchar(1000) not null,
	LanguageCode nvarchar(50) not null,
	Title nvarchar(1000) not null,  ---新闻标题
	Content nvarchar(MAX) not null,   --- 新闻内容
	CreateDate datetime not null,    ---新闻创建时间
	ModifyDate datetime not null,     ---新闻修改时间
	Status int not null,    ---- 新闻状态 0：未发布，1：发布，2：作废
	IssueDate datetime null,  ---- 新闻发布时间（跟Status相结合）
	Level int not null,      ----新闻级别  0：最新级别插入News，1,2,3
	Keywords nvarchar(1000) null,
	Description nvarchar(MAX) null,
	SeoTitle nvarchar(1000) null,
	Url nvarchar(225) null
)