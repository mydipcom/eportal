

USE ECP
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('CmsJob')) drop table CmsJob
GO
CREATE table CmsJob (
	ID int identity,
	Guid nvarchar(1000) not null,
	LangGuid nvarchar(1000) not null,
	LanguageCode nvarchar(50) not null,
	JobTitle nvarchar(1000) not null,
	NeedNum int null,
	Workplace nvarchar(1000) null,
	Salary nvarchar(200) null,
	LanguageRequired nvarchar(200) null,
	JobBligation nvarchar(MAX) not null,
	JobDesc nvarchar(MAX) not null,
	OrderNum int not null ,
	CreateDate datetime not null,
	Keywords nvarchar(1000) null,
	Description nvarchar(MAX) null,
	SeoTitle nvarchar(1000) null,
	Url nvarchar(225) null
)
GO

