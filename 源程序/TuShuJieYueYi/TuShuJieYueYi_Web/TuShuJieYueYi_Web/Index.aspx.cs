using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Text;
using System.Data;
using Model;

namespace TuShuJieYueYi_Web
{
    public partial class index : System.Web.UI.Page
    {
        private string strAdd;
        protected void Page_Load(object sender, EventArgs e)
        {

            EntranceBll bll1 = new EntranceBll();
            NavBLL bll2 = new NavBLL();
            NoticeBll bll3 = new NoticeBll();
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


                //加载图标信息
                DataTable dt1 = bll1.ShowEnter();
                StringBuilder str1 = new StringBuilder();
                StringBuilder str2 = new StringBuilder();
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    string type = dt1.Rows[i]["Type"].ToString();
                    if (type == "1")
                    {
                        str1.Append("<div class='col-md-4'><div class='modal-content clearfix'><a href='Labrary_introduce.aspx?Id=" + dt1.Rows[i]["Id"] + "'><span class='icon icon0" + (i + 1) + "'></span><h3>" + dt1.Rows[i]["Cname"].ToString() + "<small>" + dt1.Rows[i]["Ename"].ToString() + "</small></h3><p> " + dt1.Rows[i]["News"].ToString() + "</p></a></div></div>");
                        enter1.InnerHtml = str1.ToString();
                    }
                    else if (type == "2")
                    {
                        str2.Append("<div class='col-xs-12 col-md-4 clearfix'><a href='Labrary_introduce.aspx?Id=" + dt1.Rows[i]["Id"] + "' class='img-circle text-center'><img src='img/icon08.png' width='37' height='62'></a><h3><a href='Labrary_introduce.aspx?Id=" + dt1.Rows[i]["Id"] + "'>" + dt1.Rows[i]["Cname"] + "<small>" + dt1.Rows[i]["Ename"] + "</small></a></h3><p>" + dt1.Rows[i]["News"] + "</p><a href='Labrary_introduce.aspx?Id=" + dt1.Rows[i]["Id"] + "' class='btn btn-more'>MORE</a></div>");
                        enter2.InnerHtml = str2.ToString();
                    }
                }

                //加载通知信息
                DataTable dt3 = bll3.showNotice();
                StringBuilder str5 = new StringBuilder();
                if (dt3.Rows.Count > 0)
                {
                    for (int i = dt3.Rows.Count - 1; i > dt3.Rows.Count - 11; i--)
                    {
                        str5.Append("<li><a href='#'>" + dt3.Rows[i]["Title"].ToString() + "</a></li>");
                        inform.InnerHtml = str5.ToString();
                    }

                }
                else
                {
                    inform.InnerHtml = "暂无通知数据！";
                }
            }

        }
    }
}