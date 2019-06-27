using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TuShuJieYueYi_Web
{
    public partial class Enter_Exam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NavBLL bll2 = new NavBLL();
            if(!IsPostBack)
            {
                //加载导航信息
                DataTable dt2 = bll2.NavQuery();
                StringBuilder str3 = new StringBuilder();
                StringBuilder str4 = new StringBuilder();
                if (dt2.Rows.Count > 0)
                {
                    str3.Append("<li class='active'><a href='" + dt2.Rows[0]["url"].ToString() + "'>" + dt2.Rows[0]["name"] + "</a></li>");
                    str4.Append("<li><a href='" + dt2.Rows[0]["url"].ToString() + "'>" + dt2.Rows[0]["name"] + "</a>|</li>");
                    for (int i = 1; i < dt2.Rows.Count; i++)
                    {
                        str3.Append("<li><a href='" + dt2.Rows[i]["url"].ToString() + "'>" + dt2.Rows[i]["name"] + "</a></li>");
                        str4.Append("<li><a href='" + dt2.Rows[i]["url"].ToString() + "'>" + dt2.Rows[i]["name"] + "</a>|</li>");
                    }
                    nav1.InnerHtml = str3.ToString();
                    nav2.InnerHtml = str4.ToString();
                }
            }
            
        }
    }
}