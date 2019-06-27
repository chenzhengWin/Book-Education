using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
using Model;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TuShuJieYueYi_Web.Admin.Nav
{
    public partial class NavList : System.Web.UI.Page
    {
        BLL.NavBLL navBll = new BLL.NavBLL();
        //NavBLL bll = new NavBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }

        protected void BindRepeater()
        {
            DataTable dt = navBll.NavQuery();
            repNavList.DataSource = dt;
            repNavList.DataBind();
            
            //repList.DataSource = dt;
            //repList.DataBind();
        }

        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string caozuo = e.CommandName.ToString();
            int id = Convert.ToInt32(e.CommandArgument);
            if (caozuo == "Edit")
            {
                Response.Redirect("NavEdit.aspx?id=" + id + "");
            }
        }
    }
}