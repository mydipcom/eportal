

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

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','news','lbl','aama_news_lab_abstract_title',N'摘要') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','news','lbl','aama_news_lab_abstract_title',N'Abstract') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','news','lbl','aama_news_lab_apply_title',N'报名参加') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','news','lbl','aama_news_lab_apply_title',N'Enter for') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','news','lbl','aama_news_lab_apply',N'报名表') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','news','lbl','aama_news_lab_apply',N'Application form') 

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','lbl','aama_common_lab_fullname',N'姓名') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','lbl','aama_common_lab_fullname',N'Full Name') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','lbl','aama_common_lab_duty',N'职务') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','lbl','aama_common_lab_duty',N'Duty')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','lbl','aama_common_lab_organization',N'机构') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','lbl','aama_common_lab_organization',N'Organization') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','lbl','aama_common_lab_phone',N'电话') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','lbl','aama_common_lab_phone',N'Phone') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','lbl','aama_common_lab_email',N'邮箱') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','lbl','aama_common_lab_email',N'E-mail') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','lbl','aama_common_lab_remark',N'备注') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','lbl','aama_common_lab_remark',N'Remark') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','lbl','aama_common_lab_coupons',N'使用优惠劵') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','lbl','aama_common_lab_coupons',N'Use Coupons') 


insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','button','lbl','aama_button_lab_submit',N'提交') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','button','lbl','aama_button_lab_submit',N'Submit') 

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','input','aama_common_input_name',N'请输入您的姓名') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','input','aama_common_input_name',N'Please input your name') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','input','aama_common_input_duty',N'请输入您的职务') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','input','aama_common_input_duty',N'Please input your duty') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','input','aama_common_input_organization',N'请输入您所在的机构') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','input','aama_common_input_organization',N'Please input your Organization') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','input','aama_common_input_phone',N'请输入您的电话号码') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','input','aama_common_input_phone',N'Please enter your phone number') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','input','aama_common_input_email',N'请输入您的邮箱') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','input','aama_common_input_email',N'Please input your email address') 


GO
    
    

            
SELECT TOP 1000 [ID]
      ,[LanguageCode]
      ,[ResourcePage]
      ,[ResourceType]
      ,[ResourceKey]
      ,[ResourceValue]
  FROM [AAMA].[dbo].[SysResource]  