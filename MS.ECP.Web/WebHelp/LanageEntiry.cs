using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MS.ECP.Utility;

namespace MS.ECP.Web.WebHelp
{

    #region LanageCommon

    public class LanageCommon
    {
        private static readonly ResourcesHelper ReHelper = new ResourcesHelper("Common");

        public static string CurrenLanage
        {
            get
            {
                return ResourcesHelper.GetLang();
            }
        }

        public static string CommanyName  
        {
            get
            {
                return ReHelper.GetString("common_seo_companyname");
            }
        }


        public static string CommonSeoTitle 
        {
            get
            {
                return ReHelper.GetString("common_seo_title");
            }
        }


        public static string CommonSeoKeywords 
        {
            get
            {
                return ReHelper.GetString("common_seo_keywords");
            }
        }


        public static string HomeSeoTitle
        {
            get
            {
                return ReHelper.GetString("home_seo_title");
            }
        }

        public static string HomeSeoKeywords
        {
            get
            {
                return ReHelper.GetString("home_seo_keywords");
            }
        }

        public static string HomeSeoDescription
        {
            get
            {
                return ReHelper.GetString("home_seo_description");
            }
        }

        public static string CommonSeoDescription
        {
            get
            {
                return ReHelper.GetString("common_seo_description");
            }
        }  


        public static string TechnologiesSeoTitle   
        {
            get
            {
                return ReHelper.GetString("technologies_seo_title");
            }
        }

        public static string TechnologiesSeoKeywords
        {
            get
            {
                return ReHelper.GetString("technologies_seo_keywords");
            }
        }

        public static string TechnologiesSeoDescription
        {
            get
            {
                return ReHelper.GetString("technologies_seo_description");
            }
        }


        public static string SolutionsSeoTitle
        {
            get
            {
                return ReHelper.GetString("solutions_seo_title");
            }
        }

        public static string SolutionsSeoKeywords
        {
            get
            {
                return ReHelper.GetString("solutions_seo_keywords");
            }
        }

        public static string SolutionsSeoDescription  
        {
            get
            {
                return ReHelper.GetString("solutions_seo_description");
            }
        }



        public static string AboutusSeoTitle
        {
            get
            {
                return ReHelper.GetString("aboutus_seo_title");
            }
        }

        public static string AboutusSeoKeywords
        {
            get
            {
                return ReHelper.GetString("aboutus_seo_keywords");
            }
        }

        public static string AboutusSeoDescription
        {
            get
            { 
                return ReHelper.GetString("aboutus_seo_description");
            }
        }





        public static string WorkwithusSeoTitle
        {
            get
            {
                return ReHelper.GetString("workwithus_seo_title");
            }
        }

        public static string WorkwithusSeoKeywords
        {
            get
            {
                return ReHelper.GetString("workwithus_seo_keywords");
            }
        }

        public static string WorkwithusSeoDescription
        {
            get
            {
                return ReHelper.GetString("workwithus_seo_description");
            }
        }





        public static string NewsSeoTitle
        {
            get
            {
                return ReHelper.GetString("news_seo_title");
            }
        }

        public static string NewsSeoKeywords
        {
            get
            {
                return ReHelper.GetString("news_seo_keywords");
            }
        }

        public static string NewsSeoDescription
        { 
            get
            {
                return ReHelper.GetString("news_seo_description");
            }
        }


        public static string NewsdetailSeoTitle
        {
            get
            { 
                return ReHelper.GetString("newsdetail_seo_title");
            }
        }

        public static string NewsdetailSeoKeywords
        {
            get
            {
                return ReHelper.GetString("newsdetail_seo_keywords");
            }
        }

        public static string NewsdetailSeoDescription
        {
            get
            {
                return ReHelper.GetString("newsdetail_seo_description");
            }
        }



        public static string LinkmoreLblCloud   
        {
            get
            {
                return ReHelper.GetString("linkmore_lbl_link1");
            }
        }


        public static string LinkmoreLblEcommerce
        {
            get
            {
                return ReHelper.GetString("linkmore_lbl_link2");
            }
        }


        public static string LinkmoreLblBigdata
        {
            get
            {
                return ReHelper.GetString("linkmore_lbl_link3");
            }
        }

        public static string LinkmoreLblSamrtcity
        {
            get
            {
                return ReHelper.GetString("linkmore_lbl_link4");
            }
        }


        public static string LinkmoreLblEcommerce2
        {
            get
            {
                return ReHelper.GetString("linkmore_lbl_link5");
            }
        }



        public static string LinkmoreLblMobileapp
        {
            get
            {
                return ReHelper.GetString("linkmore_lbl_link6");
            }
        }

        






        public static string IndexLabLbBigdataCaption
        {
            get
            {
                return ReHelper.GetString("index_lab_lb_bigdata_caption");
            }
        }

        public static string FootLblNewsCaption
        {
            get
            {
                return ReHelper.GetString("foot_lbl_news_caption");
            }
        }

        public static string SysLabReadmore
        {
            get
            {
                return ReHelper.GetString("sys_lab_readmore");
            }
        }


        public static string FootLblAboutusCaption
        {
            get
            {
                return ReHelper.GetString("foot_lbl_aboutus_caption");
            }
        }


        public static string FootLblAboutus
        {
            get
            {
                return ReHelper.GetString("foot_lbl_aboutus");
            }
        }

        public static string FootLblPhotoCaption
        {
            get
            {
                return ReHelper.GetString("foot_lbl_photo_caption");
            }
        }

        public static string FootLblFollowCaption
        {
            get
            {
                return ReHelper.GetString("foot_lbl_follow_caption");
            }
        }

        public static string IndexLabLbBigdata
        {
            get
            {
                return ReHelper.GetString("index_lab_lb_bigdata");
            }
        }

        public static string IndexLabLbCloudCaption
        {
            get
            {
                return ReHelper.GetString("index_lab_lb_cloud_caption");
            }
        }

        public static string IndexLabLbCloud
        {
            get
            {
                return ReHelper.GetString("index_lab_lb_cloud");
            }
        }

        public static string IndexLabLbEcommerceCaption
        {
            get
            {
                return ReHelper.GetString("index_lab_lb_ecommerce_caption");
            }
        }

        public static string FootLblFollow
        {
            get
            {
                return ReHelper.GetString("foot_lbl_follow");
            }
        }

        public static string IndexLabLbEcommerce
        {
            get
            {
                return ReHelper.GetString("index_lab_lb_ecommerce");
            }
        }

        public static string IndexLabTechnolgy1Caption
        {
            get
            {
                return ReHelper.GetString("index_lab_technolgy1_caption");
            }
        }

        public static string IndexLabTechnolgy1
        {
            get
            {
                return ReHelper.GetString("index_lab_technolgy1");
            }
        }

        public static string IndexLabTechnolgy2Caption
        {
            get
            {
                return ReHelper.GetString("index_lab_technolgy2_caption");
            }
        }

        public static string IndexLabTechnolgy2
        {
            get
            {
                return ReHelper.GetString("index_lab_technolgy2");
            }
        }

        public static string IndexLabTechnolgy3Caption
        {
            get
            {
                return ReHelper.GetString("index_lab_technolgy3_caption");
            }
        }

        public static string IndexLabTechnolgy3
        {
            get
            {
                return ReHelper.GetString("index_lab_technolgy3");
            }
        }

        public static string MenuLblSolutions
        {
            get
            {
                return ReHelper.GetString("menu_lbl_solutions");
            }
        }

        public static string MenuLblTechnologies
        {
            get
            {
                return ReHelper.GetString("menu_lbl_technologies");
            }
        }

        public static string MenuLblWorkwithus
        {
            get
            {
                return ReHelper.GetString("menu_lbl_workwithus");
            }
        }

        public static string WorkaboutusLblParentTitle
        {
            get
            {
                return ReHelper.GetString("workaboutus_lbl_parent_title");
            }
        }


        public static string MenuLblHomepage
        {
            get
            {
                return ReHelper.GetString("menu_lbl_homepage");
            }
        }


        public static string MenuLblAboutus
        {
            get
            {
                return ReHelper.GetString("menu_lbl_aboutus");
            }
        }


        public static string NewsLblTabNews  
        {
            get
            {
                return ReHelper.GetString("news_lbl_tab_news");
            }
        }

        public static string FootLblCopyright   
        {
            get
            {
                return ReHelper.GetString("foot_lbl_copyright");
            }
        }

        public static string WorkaboutusLblJobWorkplace    
        {
            get
            {
                return ReHelper.GetString("workaboutus_lbl_job_workplace");
            }
        }


        public static string WorkaboutusLblJobLanguage
        {
            get
            {
                return ReHelper.GetString("workaboutus_lbl_job_language");
            }
        }


        public static string WorkaboutusLblJobSalary
        {
            get
            {
                return ReHelper.GetString("workaboutus_lbl_job_salary");
            }
        }


        public static string WorkaboutusLblJobReleasetime
        {
            get
            {
                return ReHelper.GetString("workaboutus_lbl_job_releasetime");
            }
        }


        public static string WorkaboutusLblJobResponsibilities
        {
            get
            {
                return ReHelper.GetString("workaboutus_lbl_job_responsibilities");
            }
        }

        public static string WorkaboutusLblJobFunctional 
        {
            get  
            {
                return ReHelper.GetString("workaboutus_lbl_job_functional");
            }
        }
    }

    #endregion


    #region LanageDefault

    public class LanageDefault
    {
        private static readonly ResourcesHelper ReHelper = new ResourcesHelper("Default");


    }

    #endregion


    #region LanageRegister

    public class LanageRegister
    {
        private static readonly ResourcesHelper ReHelper = new ResourcesHelper("Register");
        public static string SysTitle 
        {
            get
            {
                return ReHelper.GetString("sys_title");
            }
        }

        public static string SysKeywords
        {
            get
            {
                return ReHelper.GetString("sys_keywords");
            }
        }

        public static string SysDescription
        {
            get
            {
                return ReHelper.GetString("sys_description");
            }
        }


        public static string SysFooter
        {
            get
            {
                return ReHelper.GetString("sys_footer");
            }
        }
    }

    #endregion


    #region LanageAbout

    public class LanageAbout
    {
        private static readonly ResourcesHelper ReHelper = new ResourcesHelper("About");

        public static string SysTitle
        {
            get
            {
                return ReHelper.GetString("sys_title");
            }
        }

        public static string SysKeywords
        {
            get
            {
                return ReHelper.GetString("sys_keywords");
            }
        }

        public static string SysDescription
        {
            get
            {
                return ReHelper.GetString("sys_description");
            }
        }

        public static string SysFooter
        {
            get
            {
                return ReHelper.GetString("sys_footer");
            }
        }

        public static string AboutusLblProfileCaption
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_profile_caption");
            }
        }

        public static string AboutusLblFeedbackCaption
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_feedback_caption");
            }
        }

        public static string AboutusLblIdeaCaption
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_idea_caption");
            }
        }

        public static string MenuLblAboutus
        {
            get
            {
                return ReHelper.GetString("menu_lbl_aboutus");
            }
        }
        
        public static string AboutusLblProfile
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_profile");
            }
        }

        public static string AboutusLblFeedbackName
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_feedback_name");
            }
        }

        public static string AboutusLblIdea
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_idea");
            }
        }

        public static string AboutusLblFeedbackSubject
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_feedback_subject");
            }
        }

        public static string AboutusLblFeedbackBody
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_feedback_body");
            }
        }

        public static string AboutusLblFeedbackSend
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_feedback_send");
            }
        }

        public static string AboutusLblFeedbackContactAddress
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_feedback_contact_address");
            }
        }

        public static string AboutusLblAddress
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_address");
            }
        }

        public static string AboutusLblFeedbackContactPhone
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_feedback_contact_phone");
            }
        }


        public static string AboutusLblFeedbackRemark
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_feedback_remark");
            }
        }

        public static string AboutusLblFeedbackContact
        {
            get
            {
                return ReHelper.GetString("aboutus_lbl_feedback_contact");
            }
        }

        public static string CommonLblCompanyname 
        {
            get
            {
                return ReHelper.GetString("common_lbl_companyname");
            }
        }
    }

    #endregion
}