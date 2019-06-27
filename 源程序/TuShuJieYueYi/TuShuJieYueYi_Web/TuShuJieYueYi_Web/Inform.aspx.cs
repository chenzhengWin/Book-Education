using BLL;
using Model;
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
    public partial class Inform : System.Web.UI.Page
    {
        private string strAdd;
        NoticeBll bll = new NoticeBll();
        NavBLL bll2 = new NavBLL();
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

                //加载通知信息
                DataTable dt = bll.showNotice();
                StringBuilder str = new StringBuilder();
                if (dt.Rows.Count > 0)
                {
                    for (int i = dt.Rows.Count - 1; i > 0; i--)
                    {
                        str.Append("<li><span class='time'>" + dt.Rows[i]["Time"].ToString() + "</span><a href='Infrom_introduce.aspx?Id=" + Convert.ToInt32(dt.Rows[i]["Id"]) + "'>" + dt.Rows[i]["Title"].ToString() + "</a></li>");
                    }
                    inform.InnerHtml = str.ToString();
                }
                else
                {
                    inform.InnerHtml = "暂无通知数据！";
                }
            }
            else
            {
                string content = Request["tt"].ToString();
                DataTable dt = bll.seekNotice(content);
                StringBuilder str = new StringBuilder();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        str.Append("<li><span class='time'>" + dt.Rows[i]["Time"].ToString() + "</span><a href='Infrom_introduce.aspx?Id=" + Convert.ToInt32(dt.Rows[i]["Id"]) + "'>" + dt.Rows[i]["Title"].ToString() + "</a></li>");
                    }
                    inform.InnerHtml = str.ToString();
                }
                else
                {
                    inform.InnerHtml = "暂无该内容通知数据！";
                }

            }
        }

        protected void seek_Click(object sender, EventArgs e)
        {

        }
    }
}