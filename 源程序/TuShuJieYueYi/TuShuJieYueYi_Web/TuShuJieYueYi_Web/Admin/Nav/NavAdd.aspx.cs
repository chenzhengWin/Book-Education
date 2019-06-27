using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace TuShuJieYueYi_Web.Admin.Nav
{
    public partial class NavAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOk_ServerClick(object sender, EventArgs e)
        {
            NavBLL bll = new NavBLL();
            string name = navname.Value;
            string url = navurl.Value;
            if (name != "")
            {
                DataTable dt = bll.NavQuery();
                foreach (DataRow item in dt.Rows)
                {
                    if (item["name"].ToString() == name)
                    {
                        Response.Write("<script>alert('导航名不能重复！！！');</script>");
                        navname.Value = "";
                        return;
                    }
                }


                //DataTable dt = bll.NavQuery();
                int result = bll.NavAdd(name,url);
                if (result > 0)
                {
                    Context.Response.Write("<script>alert('添加成功')</script>");
                    Context.Response.Redirect("NavList.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('导航名不能为空！！！');</script>");
            }
        }
    }
}