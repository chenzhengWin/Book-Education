using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data.SqlClient;
using System.Data;

namespace TuShuJieYueYi_Web.Admin.Users
{
    public partial class userAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sub_btn_ServerClick(object sender, EventArgs e)
        {
            string username = txtUserName.Value;
            string pwd = txtPassword.Value;
            AdminBLL admin = new AdminBLL();
            //验证
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
            
            if (tag)
            {
                DataTable dt = admin.adminsel();
                bool tag2 = true;
                foreach (DataRow item in dt.Rows)
                {
                  
                    if (item["username"].ToString() == username)
                    {
                        Response.Write("<script>alert('用户名重复！！！');</script>");
                        txtUserName.Value = "";
                        tag2 = false;
                        return;

                    } 
                }
                 
                int result = admin.adminadd(username, pwd);   
                if (result > 0)
                {
                    txtUserName.Value = "";
                    Response.Write("<script>alert('添加成功！！！')</script>");
                }


            }
            
           
           
         
        }

    
    }
}