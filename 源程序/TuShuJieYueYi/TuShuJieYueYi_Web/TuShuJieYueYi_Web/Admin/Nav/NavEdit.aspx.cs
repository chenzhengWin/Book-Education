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
    public partial class NavEdit : System.Web.UI.Page
    {
        BLL.NavBLL navBll = new NavBLL();
        // NavBLL bll = new NavBLL();
        Navigation Nav = new Navigation();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["id"]);
            Nav = navBll.NavQuery(id);

            if (!IsPostBack)
            {
                oldname.Value = Nav.Name;
            }

        }

        protected void btnOk_ServerClick(object sender, EventArgs e)
        {
            string old = oldname.Value;
            string news = newname.Value;
            string url=newUrl.Value;
            NavBLL bll = new NavBLL();
            if (old == news)
            {
                Response.Write("<script>alert('请输入不同的导航名')</script>");
            }
            else
            {
                if (news != "")
                {
                    DataTable dt = bll.NavQuery();
                    foreach (DataRow item in dt.Rows)
                    {
                        if (item["name"].ToString() == news)
                        {
                            Response.Write("<script>alert('导航名不能重复！！！');</script>");
                            newname.Value = "";
                            return;
                        }
                    }
                    int result = navBll.NavEdit(newname.Value,newUrl.Value, Nav.Id);
                    if (result > 0)
                    {
                        Response.Write("<script>alert('修改成功')</script>");
                        Response.Redirect("NavList.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('导航名不能为空！！！');</script>");
                }

            }
        }
    }
}