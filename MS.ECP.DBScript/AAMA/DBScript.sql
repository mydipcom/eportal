USE AAMA

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('SysResource')) drop table SysResource
GO
CREATE table SysResource (
	ID int identity,
	LanguageCode nvarchar(50) not null,
	ResourcePage nvarchar(200) not null,
	ResourceType nchar(10) not null,
	ResourceKey  nvarchar(255) not null,
	ResourceValue nvarchar(MAX) not null	
)
GO

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','logon','lbl','aama_logon_lbl_welcome',N'欢迎您' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','logon','lbl','aama_logon_lbl_logout',N'退出' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','logon','lbl','aama_logon_lbl_login',N'登录' )

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','menu','lbl','aama_menu_lbl_homepage',N'首页')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','menu','lbl','aama_menu_lbl_aboutus',N'关于我们')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','menu','lbl','aama_menu_lbl_events',N'活动')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','menu','lbl','aama_menu_lbl_news',N'最新动态')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','menu','lbl','aama_menu_lbl_contactus',N'联系我们')


insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','logon','lbl','aama_logon_lbl_welcome',N'Welcome' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','logon','lbl','aama_logon_lbl_logout',N'Logoff' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','logon','lbl','aama_logon_lbl_login',N'Login' )

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','menu','lbl','aama_menu_lbl_homepage',N'Home')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','menu','lbl','aama_menu_lbl_aboutus',N'About Us')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','menu','lbl','aama_menu_lbl_events',N'Events')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','menu','lbl','aama_menu_lbl_news',N'News')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','menu','lbl','aama_menu_lbl_contactus',N'Contact US')

/****-------Index**/
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','aama_sys_lab_readmore',N'更多')

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','aama_sys_lab_readmore',N'More')  
  
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','aama_index_lab_lb_busi_network_caption',N'营商网络')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','aama_index_lab_lb_busi_network',N'营商网络。。。。')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','aama_index_lab_lb_entrepreneur_caption',N'创业摇篮')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','aama_index_lab_lb_entrepreneur',N'创业摇篮。。。。')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','aama_index_lab_lb_professional_caption',N'专业人才')                                                                        
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','aama_index_lab_lb_professional',N'专业人才。。。。')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','aama_index_lab_lb_investment_caption',N'投资机遇')                                                                        
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','aama_index_lab_lb_investment',N'投资机遇。。。。')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','aama_index_lab_lb_community_caption',N'回馈社会')                                                                        
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','aama_index_lab_lb_community',N'回馈社会。。。。')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','aama_index_lab_lb_sponsors',N'合作伙伴')

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','aama_index_lab_lb_busi_network_caption',N'Business Networking')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','aama_index_lab_lb_busi_network',N'Business Networking 。。。。' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','aama_index_lab_lb_entrepreneur_caption',N'Entrepreneurship ' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','aama_index_lab_lb_entrepreneur',N'Entrepreneurship 。。。。' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','aama_index_lab_lb_professional_caption',N'Professional Talent')                                                    
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','aama_index_lab_lb_professional',N'Professional Talent。。。。' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','aama_index_lab_lb_investment_caption',N'Investment Venture')                               
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','aama_index_lab_lb_investment',N'Investment Venture。。。。' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','aama_index_lab_lb_community_caption',N'Community Service')                                                          
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','aama_index_lab_lb_community',N'Community Service。。。。' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','aama_index_lab_lb_sponsors',N'Sponsors' )


insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','outside','lbl','aama_outside_lab_usa',N'美国分会') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','outside','lbl','aama_outside_lab_beijing',N'北京分会') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','outside','lbl','aama_outside_lab_shanghai',N'上海分会') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','outside','lbl','aama_outside_lab_taibei',N'台北分会') 

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','outside','lbl','aama_outside_lab_usa',N'AAMA USA') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','outside','lbl','aama_outside_lab_beijing',N'AAMA Beijing') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','outside','lbl','aama_outside_lab_shanghai',N'AAMA Shanghai') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','outside','lbl','aama_outside_lab_taibei',N'AAMA Taipei') 

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','foot','lbl','aama_foot_lab_remark',N'亚杰商会  珠三角分会') 

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','foot','lbl','aama_foot_lab_remark',N'AAMA Pearl River Delta Chapter') 

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','contactus','lbl','aama_contactus_lab_address_caption',N'办公地点') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','contactus','lbl','aama_contactus_lab_address',N'香港中環皇后大道中99號2703,27楼') 

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','contactus','lbl','aama_contactus_lab_address_caption',N'Office Location: ') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','contactus','lbl','aama_contactus_lab_address',N'2703, 27/F, The Center,99 Queen‘s Road Central,Hong Kong ') 

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','events','lbl','aama_events_lab_title',N'所有活动') 

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','events','lbl','aama_events_lab_title',N'All Events') 

GO   


/****  UserInfo    **/
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
insert into UserInfo( Guid,UserName,Email,Password,FirstName,LastName,PhoneNumber,UserType,Status,CreateDate,ModifyDate) values ('38d5afd5-3cbb-4741-b2f9-abeeec4ea5bd','admin','admin@missionsky.com','admin','Admin','Admin','15949507894',0,1,'11/12/2013','11/12/2013');
GO


/****  Language     **/
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('SysLanguage')) drop table SysLanguage
GO
CREATE table SysLanguage (
	ID int identity,
	Guid nvarchar(1000) not null,
	LangCode nvarchar(50) not null,
	LangText nvarchar(255) not null,
	LangStatus nvarchar(50) not null,
	LangOrder int not null,
	Status int null,
)
GO

insert into SysLanguage (Guid, LangCode, LangText, LangStatus, LangOrder, Status ) values ('2EA7D003-475D-4F2D-8F3D-55472C1F23A6','zh-cn',N'简体中文',1,0,0)
insert into SysLanguage (Guid, LangCode, LangText, LangStatus, LangOrder, Status) values ('C9C5D2F8-DC4E-453B-BD4F-1048010CB722','en-us',N'English',1,1,0)



/****  News     **/
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


/****     Event       ***/
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('CmsEvent')) drop table CmsEvent
GO
CREATE table CmsEvent (
	ID int identity,  -----id
	Guid nvarchar(1000) not null,
	LangGuid nvarchar(1000) not null,
	LanguageCode nvarchar(50) not null,
	Title nvarchar(1000) not null,  ---活动标题
	Content nvarchar(MAX) not null,   --- 活动内容
	CreateDate datetime not null,    ---活动创建时间
	ModifyDate datetime not null,     ---活动修改时间
	Status int not null,    ---- 活动状态 0：未发布，1：发布，2：作废
	IssueDate datetime null,  ---- 活动发布时间（跟Status相结合）
	Level int not null,      ----活动级别  0：最新级别插入News，1,2,3
	Keywords nvarchar(1000) null,
	Description nvarchar(MAX) null,
	SeoTitle nvarchar(1000) null,
	Url nvarchar(225) null
)

/****  Aboutus ****/
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





