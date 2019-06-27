using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;
using System.Text;

namespace TuShuJieYueYi_Web
{
    public partial class Infrom_introduce : System.Web.UI.Page
    {
        NoticeBll bll = new NoticeBll();
        public string Title { get; set; }
        public string News { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            NavBLL bll2 = new NavBLL();
            if (!IsPostBack)
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

                //加载单条通知详情
                int id = Convert.ToInt32(Request["Id"]);
                Notice model = new Notice();
                DataTable dt = bll.QueryNotice(id);
                DataRow dr = dt.Rows[0];
                if (dt.Rows.Count > 0)
                {
                    Title = dr["title"].ToString();
                    News = dr["news"].ToString();
                    tt.InnerHtml = News;
                }
            }
        }
    }
}