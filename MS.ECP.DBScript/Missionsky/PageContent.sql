/****** Script for SelectTopNRows command from SSMS  ******/
USE ECP
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('CmsPageContent')) drop table CmsPageContent
GO
CREATE table CmsPageContent (
	ID int identity,
	Guid nvarchar(1000) not null,
    PageNumber int null,
	Item nvarchar(1000) not null,
	ItemContent nvarchar(MAX) not null,
	LanguageCode nvarchar(50) not null,
	CategoryID int not null,
	CreateDate dateTime not null,
	Keywords nvarchar(1000) null,
	Description nvarchar(MAX) null,
	SeoTitle nvarchar(1000) null,
	Url nvarchar(225) null 	
)
GO
