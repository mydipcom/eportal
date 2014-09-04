USE ecpteam
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

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','logon','lbl','logon_lbl_welcome',N'欢迎您' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','logon','lbl','logon_lbl_logout',N'退出' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','logon','lbl','logon_lbl_login',N'登录' )

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','menu','lbl','menu_lbl_homepage',N'首页')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','menu','lbl','menu_lbl_technologies',N'技术方案')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','menu','lbl','menu_lbl_solutions',N'解决方案')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','menu','lbl','menu_lbl_aboutus',N'关于我们')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','menu','lbl','menu_lbl_workwithus',N'加入我们')


insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','logon','lbl','logon_lbl_welcome',N'Welcome' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','logon','lbl','logon_lbl_logout',N'Logoff' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','logon','lbl','logon_lbl_login',N'Login' )

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','menu','lbl','menu_lbl_homepage',N'HOME')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','menu','lbl','menu_lbl_technologies',N'TECHNOLOGIES')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','menu','lbl','menu_lbl_solutions',N'SOLUTIONS')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','menu','lbl','menu_lbl_aboutus',N'ABOUT US')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','menu','lbl','menu_lbl_workwithus',N'WORK WITH US')

/****-------Index**/
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','sys_lab_readmore',N'更多')  
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','index_lab_lb_bigdata_caption',N'大数据')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','index_lab_lb_bigdata',N'大数据技术的战略意义不在于掌握庞大的数据信息，而在于对这些含有意义的数据进行专业化处理。换言之，如果把大数据比作一种产业，那么这种产业实现盈利的关键，在于提高对数据的“加工能力”。' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','index_lab_lb_cloud_caption',N'云计算' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','index_lab_lb_cloud',N'云计算产业链、行业生态环境基本稳定；各厂商解决方案更加成熟稳定，提供丰富的XaaS产品。用户云计算应用取得良好的绩效，并成为IT系统不可或缺的组成部分，云计算成为一项基础设施。' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','index_lab_lb_ecommerce_caption',N'电子商务' )                                                                        
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','index_lab_lb_ecommerce',N'电子商务、网络营销是当代信息社会中数据处理技术、电子技术及网络技术综合应用于商贸领域中的产物，或者说它是当代高新信息手段与商贸实务和营销策略相互融合的结果。引发了信息社会中商贸实务和营销策略研究领域中一场深刻而激动人心的革命。' )


insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','index_lab_technolgy1_caption',N'智慧城市') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','index_lab_technolgy1',N'智慧城市是把新一代信息技术充分运用在城市的各行各业之中的基于知识社会下一代创新的城市信息化高级形态。智慧城市基于物联网、云计算等新一代信息技术以及维基、社交网络、综合集成法等工具和方法的应用，营造有利于创新涌现的生态，实现全面透彻的感知') 
            
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','index_lab_technolgy2_caption',N'电子商务') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','index_lab_technolgy2',N'电子商务通常是指是在全球各地广泛的商业贸易活动中，在因特网开放的网络环境下，基于浏览器服务器应用方式，买卖双方不谋面地进行各种商贸活动，
            实现消费者的网上购物、商户之间的网上交易和在线电子支付以及各种商务活动、交易活动') 
            
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','index_lab_technolgy3_caption',N'移动应用')             
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','index','lbl','index_lab_technolgy3',N'计算时代的到来，使得企业信息化这一话题又有了新的生命。在云端不断增强移动应用的服务性能之外最显著的特征就是在端的精彩表现。
            单纯用PC来使用ERP的时代将一去不复返。以手机、平板电脑介质为代表的移动终端应用将为企业信息化带来巨大变革。')    
            
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','sys_lab_readmore',N'MORE')  

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','index_lab_lb_bigdata_caption',N'Big Data')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','index_lab_lb_bigdata',N'Big Data。。。。。' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','index_lab_lb_cloud_caption',N'Cloud Computing' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','index_lab_lb_cloud',N'Cloud Computing。。。。。' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','index_lab_lb_ecommerce_caption',N'Electronic Commerce' )                                                                        
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','index_lab_lb_ecommerce',N'Electronic Commerce。。。。。' )


insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','index_lab_technolgy1_caption',N'SMART CITY') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','index_lab_technolgy1',N'Smart city。。。。。')             
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','index_lab_technolgy2_caption',N'ELECTRONIC COMMERCE') 
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','index_lab_technolgy2',N'Electronic Commerce。。。。。')             
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','index_lab_technolgy3_caption',N'MOBILE APPLICATION')             
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','index','lbl','index_lab_technolgy3',N'Mobile Application。。。。。')

/****-------Foot**/
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','foot','lbl','foot_lbl_aboutus_caption',N'关于我们')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','foot','lbl','foot_lbl_aboutus',N'深圳凌云创新科技有限公司是一家专注于提供企业云端解决方案的高科技公司，总部在中国香港。公司成立于2012年。。。。。。')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','foot','lbl','foot_lbl_photo_caption',N'企业照片')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','foot','lbl','foot_lbl_news_caption',N'企业新闻')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','foot','lbl','foot_lbl_news_link',N'开展每月户外活动')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','foot','lbl','foot_lbl_news',N'为了丰富精神文化生活，促进企业文化建设，快乐工作，快乐生活')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','foot','lbl','foot_lbl_follow_caption',N'关注我们')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','foot','lbl','foot_lbl_follow',N'扫描二维码加微信关注')

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','foot','lbl','foot_lbl_aboutus_caption',N'ABOUT US')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','foot','lbl','foot_lbl_aboutus',N'MissionSky Company Limited is a technology start-up company based in Hong Kong and China.')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','foot','lbl','foot_lbl_photo_caption',N'ENTERPRISE PHOTOS')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','foot','lbl','foot_lbl_news_caption',N'ENTERPRISE NEWS')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','foot','lbl','foot_lbl_news_link',N'Conduct monthly outdoor activities')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','foot','lbl','foot_lbl_news',N'In order to enrich cultural life and promote the construction of enterprise culture, happy work, happy life')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','foot','lbl','foot_lbl_follow_caption',N'FOLLOW US')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','foot','lbl','foot_lbl_follow',N'Add micro letter')

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_address',N'中国深圳市福田区泰然九路泰然工贸园213栋4A')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_address',N'4A, Building #213, Tairan Industrial Trade Park, Tairan 9th Road, Futian District, Shenzhen China')


insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_profile_caption',N'公司介绍')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_profile_caption',N'COMPANY PROFILE' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_profile',N'深圳凌云创新科技有限公司是一家专注于提供企业云端解决方案的高科技公司，总部在中国香港。公司成立于2012年，目前员工近30人，并处于飞速发展中，作为一个年轻的和动态的初创科技公司， 将会有大量的机会去积极接受挑战和发展他们的事业与公司并成长。凌云科技不以人才扩张为支撑业务发展的基础，公司以开发精品软件产品和解决方案为主要业务内容； 以高端人才带动公司的理念革新和方法进步，鼓励技术创新，追求领先的软件工程技术和方法。 公司重视并积极开展与国内外知名公司在专业领域的合作，其核心业务是为客户提供高质量及有效的IT服务,以及通过与其他公司合作从事软件产品开发创新。')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_profile',N'MissionSky Company Limited is a technology start-up company based in Hong Kong and China. Its core business is to provide high quality and cost effective IT services to enterprise clients, as well as engaging in revenue generating software product development through partnership with other companies. MissionSky is targeted to become a profitable technology company, riding on the booming application of mobile Internet technology and the ubiquitous penetration of IT in traditional industries' )

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_idea_caption',N'企业理念')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_idea_caption',N'CORPORATE MIND IDENTITY' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_idea',N'凌云科技不以人才扩张为支撑业务发展的基础，公司以开发精品软件产品和解决方案为主要业务内容； 以高端人才带动公司的理念革新和方法进步，鼓励技术创新，追求领先的软件工程技术和方法。')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_idea',N'MissionSky is not supported by talents to expand business development of science and technology, the foundation of the company to develop quality software products and solutions for the main business content; On the concept of high-end talent to drive the company to innovation and improvement of the method, encourage technological innovation, the pursuit of leading software engineering techniques and methods.' )

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_feedback_caption',N'反馈信息')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_feedback_caption',N'FEEDBACK' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_feedback_remark',N'如果你有任何意见或建议,请联系我们!')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_feedback_remark',N'If you have any comments or suggestions, please contact us!' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_feedback_name',N'怎么称呼您')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_feedback_name',N'Your name' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_feedback_subject',N'留言主题')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_feedback_subject',N'Subject' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_feedback_body',N'留言内容')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_feedback_body',N'Content' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_feedback_send',N'发送')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_feedback_send',N'Submit' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_feedback_contact',N'联系方式')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_feedback_contact',N'Contact Information' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_feedback_contact_address',N'地址')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_feedback_contact_address',N'Address' )
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_lbl_feedback_contact_phone',N'电话')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_lbl_feedback_contact_phone',N'Phone' )

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','workaboutus','lbl','workaboutus_lbl_parent_title',N'招聘职位')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','workaboutus','lbl','workaboutus_lbl_parent_title',N'JOB TITLE' )

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','foot','lbl','foot_lbl_copyright',N'MissionSky Company Copyright © 2013')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','foot','lbl','foot_lbl_copyright',N'深圳凌云信息科技有限公司版权所有 © 2013')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','workaboutus','lbl','workaboutus_lbl_job_workplace',N'Workplace')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','workaboutus','lbl','workaboutus_lbl_job_workplace',N'工作地点')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','workaboutus','lbl','workaboutus_lbl_job_language',N'Language Requirment')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','workaboutus','lbl','workaboutus_lbl_job_language',N'语言要求')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','workaboutus','lbl','workaboutus_lbl_job_salary',N'Salary')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','workaboutus','lbl','workaboutus_lbl_job_salary',N'薪资待遇')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','workaboutus','lbl','workaboutus_lbl_job_releasetime',N'Release Date')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','workaboutus','lbl','workaboutus_lbl_job_releasetime',N'发布日期')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','workaboutus','lbl','workaboutus_lbl_job_responsibilities',N'Responsibilities')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','workaboutus','lbl','workaboutus_lbl_job_responsibilities',N'岗位职责')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','workaboutus','lbl','workaboutus_lbl_job_functional',N'Functional requirements')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','workaboutus','lbl','workaboutus_lbl_job_functional',N'职能要求')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','lbl','common_lbl_companyname',N'MissionSky (ShenZhen) co., LTD')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','lbl','common_lbl_companyname',N'凌云创新信息科技（深圳）有限公司')

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','news','lbl','news_lbl_tab_news',N'MissionSky News')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','news','lbl','news_lbl_tab_news',N'凌云动态')

/***SEO***/

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','home','lbl','home_seo_title',N'HOME')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','home','lbl','home_seo_title',N'首页')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','home','lbl','home_seo_keywords',N'BIG DATA,CLOUD COPMUTING,ELECTRONIC COMMERCE,SMART CITY,MOBILE APPLICATION')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','home','lbl','home_seo_keywords',N'大数据，云计算，电子商务，智慧城市，移动应用')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','home','lbl','home_seo_description',N'BIG DATA,CLOUD COPMUTING,ELECTRONIC COMMERCE,SMART CITY,MOBILE APPLICATION')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','home','lbl','home_seo_description',N'大数据，云计算，电子商务，智慧城市，移动应用')

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','technologies','lbl','technologies_seo_title',N'TECHNOLOGIES')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','technologies','lbl','technologies_seo_title',N'技术方案')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','technologies','lbl','technologies_seo_keywords',N'BIG DATA,CLOUD COPMUTING,ELECTRONIC COMMERCE,SMART CITY,MOBILE APPLICATION')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','technologies','lbl','technologies_seo_keywords',N'大数据，云计算，电子商务，智慧城市，移动应用')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','technologies','lbl','technologies_seo_description',N'BIG DATA,CLOUD COPMUTING,ELECTRONIC COMMERCE,SMART CITY,MOBILE APPLICATION')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','technologies','lbl','technologies_seo_description',N'大数据，云计算，电子商务，智慧城市，移动应用')

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','solutions','lbl','solutions_seo_title',N'SOLUTIONS')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','solutions','lbl','solutions_seo_title',N'解决方案')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','solutions','lbl','solutions_seo_keywords',N'BIG DATA,CLOUD COPMUTING,ELECTRONIC COMMERCE,SMART CITY,MOBILE APPLICATION')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','solutions','lbl','solutions_seo_keywords',N'大数据，云计算，电子商务，智慧城市，移动应用')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','solutions','lbl','solutions_seo_description',N'BIG DATA,CLOUD COPMUTING,ELECTRONIC COMMERCE,SMART CITY,MOBILE APPLICATION')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','solutions','lbl','solutions_seo_description',N'大数据，云计算，电子商务，智慧城市，移动应用')

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_seo_title',N'ABOUT US')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_seo_title',N'关于我们')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_seo_keywords',N'BIG DATA,CLOUD COPMUTING,ELECTRONIC COMMERCE,SMART CITY,MOBILE APPLICATION')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_seo_keywords',N'大数据，云计算，电子商务，智慧城市，移动应用')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','aboutus','lbl','aboutus_seo_description',N'BIG DATA,CLOUD COPMUTING,ELECTRONIC COMMERCE,SMART CITY,MOBILE APPLICATION')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','aboutus','lbl','aboutus_seo_description',N'大数据，云计算，电子商务，智慧城市，移动应用')

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','workwithus','lbl','workwithus_seo_title',N'WORK WITH US')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','workwithus','lbl','workwithus_seo_title',N'加入我们')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','workwithus','lbl','workwithus_seo_keywords',N'BIG DATA,CLOUD COPMUTING,ELECTRONIC COMMERCE,SMART CITY,MOBILE APPLICATION')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','workwithus','lbl','workwithus_seo_keywords',N'大数据，云计算，电子商务，智慧城市，移动应用')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','workwithus','lbl','workwithus_seo_description',N'BIG DATA,CLOUD COPMUTING,ELECTRONIC COMMERCE,SMART CITY,MOBILE APPLICATION')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','workwithus','lbl','workwithus_seo_description',N'大数据，云计算，电子商务，智慧城市，移动应用')

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','news','lbl','news_seo_title',N'ENTERPRISE NEWS')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','news','lbl','news_seo_title',N'企业新闻')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','news','lbl','news_seo_keywords',N'BIG DATA,CLOUD COPMUTING,ELECTRONIC COMMERCE,SMART CITY,MOBILE APPLICATION')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','news','lbl','news_seo_keywords',N'大数据，云计算，电子商务，智慧城市，移动应用')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','news','lbl','news_seo_description',N'BIG DATA,CLOUD COPMUTING,ELECTRONIC COMMERCE,SMART CITY,MOBILE APPLICATION')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','news','lbl','news_seo_description',N'大数据，云计算，电子商务，智慧城市，移动应用')

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','newsdetail','lbl','newsdetail_seo_title',N'NEWS')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','newsdetail','lbl','newsdetail_seo_title',N'新闻')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','newsdetail','lbl','newsdetail_seo_keywords',N'Acclea,MissionSky')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','newsdetail','lbl','newsdetail_seo_keywords',N'Acclea,MissionSky')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','newsdetail','lbl','newsdetail_seo_description',N'Acclea,MissionSky')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','newsdetail','lbl','newsdetail_seo_description',N'Accela,MissionSky')

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','lbl','common_seo_companyname',N'MissionSky (ShenZhen) co., LTD')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','lbl','common_seo_companyname',N'凌云创新科技（深圳）有限公司')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','lbl','common_seo_title',N'MissionSky')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','lbl','common_seo_title',N'凌云创新科技')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','lbl','common_seo_keywords',N'MissionSky')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','lbl','common_seo_keywords',N'凌云创新科技')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','common','lbl','common_seo_description',N'MissionSky')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','common','lbl','common_seo_description',N'凌云创新科技')

insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','linkmore','lbl','linkmore_lbl_link1',N'/en-us/home/Solutions?languid=b2802d04-7e7f-4f42-94ac-23088d62ac00')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','linkmore','lbl','linkmore_lbl_link1',N'/zh-cn/home/Solutions?languid=b2802d04-7e7f-4f42-94ac-23088d62ac00')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','linkmore','lbl','linkmore_lbl_link2',N'/en-us/home/Solutions?languid=b2802d04-7e7f-4f42-94ac-23088d62ac00')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','linkmore','lbl','linkmore_lbl_link2',N'/zh-cn/home/Solutions?languid=b2802d04-7e7f-4f42-94ac-23088d62ac00')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','linkmore','lbl','linkmore_lbl_link3',N'/en-us/home/Solutions?languid=b2802d04-7e7f-4f42-94ac-23088d62ac00')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','linkmore','lbl','linkmore_lbl_link3',N'/zh-cn/home/Solutions?languid=b2802d04-7e7f-4f42-94ac-23088d62ac00')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','linkmore','lbl','linkmore_lbl_link4',N'/en-us/home/Solutions?languid=b2802d04-7e7f-4f42-94ac-23088d62ac00')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','linkmore','lbl','linkmore_lbl_link4',N'/zh-cn/home/Solutions?languid=b2802d04-7e7f-4f42-94ac-23088d62ac00')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','linkmore','lbl','linkmore_lbl_link5',N'/en-us/home/Solutions?languid=b2802d04-7e7f-4f42-94ac-23088d62ac00')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','linkmore','lbl','linkmore_lbl_link5',N'/zh-cn/home/Solutions?languid=b2802d04-7e7f-4f42-94ac-23088d62ac00')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('en-us','linkmore','lbl','linkmore_lbl_link6',N'/en-us/home/Solutions?languid=b2802d04-7e7f-4f42-94ac-23088d62ac00')
insert into SysResource (LanguageCode,ResourcePage,ResourceType,Resourcekey, ResourceValue) values ('zh-cn','linkmore','lbl','linkmore_lbl_link6',N'/zh-cn/home/Solutions?languid=b2802d04-7e7f-4f42-94ac-23088d62ac00')


GO
            
SELECT TOP 1000 [ID]
      ,[LanguageCode]
      ,[ResourcePage]
      ,[ResourceType]
      ,[ResourceKey]
      ,[ResourceValue]
      
  FROM [ECP].[dbo].[SysResource]  