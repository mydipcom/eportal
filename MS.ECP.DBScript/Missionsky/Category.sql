USE ECP
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('CmsCategory')) drop table CmsCategory
GO
CREATE table CmsCategory (
	ID int identity,
	Guid nvarchar(1000) not null,
	Categoryname nvarchar(255) not null,
	LanguageCode nvarchar(50) not null,
	ParentGuid nvarchar(1000) not null,
	Keywords nvarchar(1000) null,
	Description nvarchar(MAX) null,
	SeoTitle nvarchar(1000) null,
	Url nvarchar(225) null	
)
GO


insert into CmsCategory (Guid,Categoryname,LanguageCode,ParentGuid,Keywords,Description,SeoTitle,Url) values ('5D6B86D3-6598-4F62-9A26-B87FE4E3D910',N'技术方案','zh-cn','0','','','','' )
insert into CmsCategory (Guid,Categoryname,LanguageCode,ParentGuid,Keywords,Description,SeoTitle,Url) values ('5D6B86D3-6598-4F62-9A26-B87FE4E3D910',N'TECHOLOGIES','en-us','0','','','','' )
insert into CmsCategory (Guid,Categoryname,LanguageCode,ParentGuid,Keywords,Description,SeoTitle,Url) values ('71635003-9E51-4F80-AAF0-8009305A9F4A',N'解决方案','zh-cn','0','','','','' )
insert into CmsCategory (Guid,Categoryname,LanguageCode,ParentGuid,Keywords,Description,SeoTitle,Url) values ('71635003-9E51-4F80-AAF0-8009305A9F4A',N'SOLUTIONS','en-us','0','','','','' )
