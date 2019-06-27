using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Text;
using System.Data;

namespace TuShuJieYueYi_Web
{
    public partial class Book_Introduce : System.Web.UI.Page
    {
        NavBLL bll2 = new NavBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.BookBll bll = new BLL.BookBll();
            //接收传过来的ID
            int newbookId = Convert.ToInt32(Request["id"]);
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

                ////新书的类别id为7
                //int kindId = 7;
                //string str = string.Format("kindId={0}", kindId);
                ////获取model实体
                //List<Book> booklist=bll.GetModelList(str);
                Book bookmodel = bll.GetBookModel(newbookId);
                StringBuilder builderContent = new StringBuilder();
                builderContent.Append("<h2>新书速递<small>/New Express</small></h2>");
                builderContent.Append("<div class='row book-info'><div class='col-md-6'><div class='col-xs-5 col-md-4 text-left' runat='server'><img src='"
                    + bookmodel.Image + "'/></div>");
                builderContent.Append("<div class='col-xs-7 col-md-8 text-left' runat='server'>");
                builderContent.Append("<h3>" + bookmodel.Bookname + "</h3><ul class='list-unstyled'>");
                builderContent.Append("<li>作者：" + bookmodel.Author + " </li>");
                builderContent.Append("<li>出版社：" + bookmodel.Publishing_hose + "</li>");
                builderContent.Append("<li>出版年：" + bookmodel.YearString + " </li>");
                builderContent.Append("<li>定价：" + bookmodel.Price + "元</li>");
                builderContent.Append("<li>装帧：" + bookmodel.Decorate + "</li>");
                builderContent.Append("<li>ISBN：" + bookmodel.Number + "</li></ul></div></div>");
                builderContent.Append("<div class='col-md-6'>");
                builderContent.Append("<blockquote class='evaluate'><p><span class='star pull-left'></span><span class='red'>8.5</span><span class='sum'>(36个人评价)</span></p>");
                builderContent.Append("<p class='info'>评价：<span class='star-lg'><em class='star-lg-hover star-lg04-hover'></em></span></p>");
                builderContent.Append("<button type='button' class='btn btn-success'>评价</button></blockquote></div></div>");
                builderContent.Append("<div id='book_content' class='book-content' runat='server'>");
                builderContent.Append("<h4>内容简介</h4><p>" + bookmodel.Book_introduce + "</p>");
                builderContent.Append("<h4>作者简介 </h4><p>" + bookmodel.Author_introduce + "</p>");
                builderContent.Append("<h4>目录 </h4><p>" + bookmodel.Catalogs + "</p>");
                builderContent.Append("</div>");
                book_content.InnerHtml = builderContent.ToString();

            }
        }
    }
}