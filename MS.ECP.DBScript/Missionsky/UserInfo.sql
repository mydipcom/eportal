USE ECP
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('UserInfo')) drop table UserInfo
GO
CREATE table UserInfo (
	ID int identity,
	Guid nvarchar(1000) not null,
	UserName nvarchar(1000) not null,
	Email nvarchar(1000) not null,
	Password nvarchar(MAX) not null,
	FirstName nvarchar(250) null,
	LastName nvarchar(250) null,
	PhoneNumber nvarchar(50) null,
	UserType int not null,
	Status int	not null,
	CreateDate datetime not null,
	ModifyDate datetime not null,
)
GO
  insert into [ECP].[dbo].[UserInfo] ( Guid,UserName,Email,Password,FirstName,LastName,PhoneNumber,UserType,Status,CreateDate,ModifyDate)
   values ('38d5afd5-3cbb-4741-b2f9-abeeec4ea5bd','admin','admin@missionsky.com','admin','Admin','Admin','15949507894',0,1,'11/12/2013','11/12/2013');