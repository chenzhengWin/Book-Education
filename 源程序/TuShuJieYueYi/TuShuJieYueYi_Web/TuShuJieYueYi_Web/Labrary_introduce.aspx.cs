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
    public partial class Labrary_introduce : System.Web.UI.Page
    {
        EntranceBll bll = new EntranceBll();
        NavBLL bll2 = new NavBLL();
        public string Cname { get; set; }
        public string Ename { get; set; }
        public string News { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
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
                if (!string.IsNullOrEmpty(Request["Id"]))
                {
                    int id = Convert.ToInt32(Request["Id"]);
                    Entrance model = new Entrance();
                    DataTable dt = bll.QueryEnter(id);
                    DataRow dr = dt.Rows[0];
                    if (dt.Rows.Count > 0)
                    {
                        Cname = dr["Cname"].ToString();
                        Ename = dr["Ename"].ToString();
                        News = dr["news"].ToString();
                        ss.InnerHtml = News;
                    }
                }
            }

        }
    }
}