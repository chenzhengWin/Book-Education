using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using DAL;


namespace TuShuJieYueYi_Web.Admin.Users
{
    public partial class userList : System.Web.UI.Page
    {
        AdminBLL bll = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //首次加载
            if (!IsPostBack)
            {

                Bind();
            } 

        }
        public void Bind()
        {
            string sql = "SELECT [Id] ,[username],[password] ,[state] FROM [Library].[dbo].[Admin]";
            //获取查询的总条数
             this.pager.RecordCount=bll.adminselcount();
             int pageIndex = this.pager.CurrentPageIndex - 1;
             int pageSize = this.pager.PageSize;
             repList.DataSource = DAL.SqlHelper.GetCurrentPage(sql,pageIndex,pageSize);
             repList.DataBind();
            
        }

        public void BindRepeater()
        {
          
            DataTable dt = bll.adminsel();
            repList.DataSource = dt;
            repList.DataBind();
        }

        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
            string caozuo = e.CommandName.ToString();
            int id = Convert.ToInt32(e.CommandArgument);
            if (caozuo == "Edit")
            {
                Response.Redirect("userEdit.aspx?id="+id+"");

            }
            else
            {
                bll.admindel(id);
                Bind();

            }
        }
        public void pager_PageChanged(object sender, EventArgs e)
        {
            Bind();

        }

    }
}