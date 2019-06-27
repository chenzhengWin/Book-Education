using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using DAL;
using System.Data;

namespace TuShuJieYueYi_Web.Admin.Books
{
    public partial class bookList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBookInfo();
            }
        }
        //创建业务逻辑层
        BookBll bll = new BookBll();
        public void BindBookInfo()
        {
            string sql = "select * from Book";
            this.pager.RecordCount = bll.GetRecordCount();
            //获取当前条数
            int pageIndex = this.pager.CurrentPageIndex - 1;
            //设置每一页显示多少条
            int pageSize = this.pager.PageSize = 3;
            repList.DataSource = DAL.SqlHelper.GetCurrentPage(sql, pageIndex, pageSize);
            repList.DataBind();

            //DataTable dt = bll.GetBookTable();
            //repList.DataSource = dt;
            //repList.DataBind();

        }
        protected void pager_PageChanged(object sender, EventArgs e)
        {
            BindBookInfo();
        }

        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string name = e.CommandName;
            int id = Convert.ToInt32(e.CommandArgument);
            if (name == "Del")
            {
                //执行删除方法
                bll.BookDelete(id);
                //重新加载
                BindBookInfo();
            }
            else if (name == "Edit")
            {
                //跳转到编辑页
                Response.Redirect("bookEdit.aspx?id=" + id);
            }
        }
        //关键词查询，即条件查询
        protected void Query_ServerClick(object sender, EventArgs e)
        {
            string key = txtkey.Value;
            DataTable dt = bll.GetGroupTable(key);
            repList.DataSource = dt;
            repList.DataBind();
            pager.Visible = false;
        }
    }
}