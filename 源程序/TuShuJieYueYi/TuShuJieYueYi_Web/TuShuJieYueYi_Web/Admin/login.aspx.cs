using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Model;
using BLL;


namespace TuShuJieYueYi_Web.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void sub_btn_ServerClick(object sender, EventArgs e)
        {
            //获取用户名和密码 
            string username = UserName.Value;
            string pwd = Pwd.Value;
            bool tag = true;
            if(username=="")
            {
                Response.Write("<script>alert('用户名不能为空！！！')</script>");
                tag = false;
                

            }
            else if(pwd=="")
            {
                Response.Write("<script>alert('密码不能为空！！！')</script>");
                tag = false;

            }
            if(tag)
            {
                AdminBLL admin = new AdminBLL();
                Adminor a1 = admin.Login(username, pwd);
                if(a1!=null)
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Response.Write("<script>alert('用户名不存在或者密码错误！！！')</script>");

                }



            }
          
           

            
            
        }
    }
}