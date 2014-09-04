USE ECP
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('CmsAboutus')) drop table CmsAboutus
GO
CREATE table CmsAboutus (
	ID int identity,  -----id
	Guid nvarchar(1000) not null,
	LangGuid nvarchar(1000) not null,
	LanguageCode nvarchar(50) not null,
	LinkTitle nvarchar(225) not null,    -- 响应标题
	Content nvarchar(MAX) not null,  ---内容
	Status int not null,      --内容状态：0无效 1有效且显示 2有效且不显示
	SortOrder int not null,  --显示排序
	
	Keywords nvarchar(1000) null,  
	Description nvarchar(MAX) null,
	SeoTitle nvarchar(1000) null,
	Url nvarchar(225) null

)