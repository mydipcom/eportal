USE ECP
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('SysLanguage')) drop table SysLanguage
GO
CREATE table SysLanguage (
	ID int identity,
	Guid nvarchar(1000) not null,
	LangGuid nvarchar(1000) not null,
	LangCode nvarchar(50) not null,
	LangText nvarchar(255) not null,
	LangStatus nvarchar(50) not null,
	LangOrder int not null,
	Status int null,
)
GO

insert into SysLanguage (Guid, LangGuid, LangCode, LangText, LangStatus, LangOrder, Status) values ('2EA7D003-475D-4F2D-8F3D-55472C1F23A6','F115180D-51C2-45D8-80C4-4B19089340DF','zh-cn',N'简体中文',1,0,0)
insert into SysLanguage (Guid, LangGuid, LangCode, LangText, LangStatus, LangOrder, Status) values ('C9C5D2F8-DC4E-453B-BD4F-1048010CB722','F115180D-51C2-45D8-80C4-4B19089340DF','en-us',N'English',1,1,0)
