using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data;
using System.Data.SqlClient;

namespace TuShuJieYueYi_Web.Admin.Users
{
    public partial class userEdit : System.Web.UI.Page
    { 
         AdminBLL bll = new AdminBLL();
         Adminor admin = new Adminor();
        protected void Page_Load(object sender, EventArgs e)
        {
            
             //接收参数
            int id =int.Parse( Request["id"]);
            if(id>0)
            { 
                admin=bll.adminsel(id);  
                if(!IsPostBack)
                { 
                    txtUserName.Value = admin.UserName;
                }
            }   
           
        }



        protected void btnOk_ServerClick(object sender, EventArgs e)
        { 
            string username=txtUserName .Value;
            string pwd = txtPassword.Value;
            string repwd = txtConfirmPwd.Value;
            if (rdoState1.Checked)//如果"可用"单选按钮被选中  则给state赋值为1
            {
                admin.State = 1;

            }
            else
            {
                admin.State = 0;
            }
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
             else if(repwd=="")
            {
                Response.Write("<script>alert('请确认密码！！！')</script>");
                tag = false;
            }

             if (tag)
             {
                 if (pwd == repwd)
                 {

                     int result = bll.adminedit(txtUserName.Value, pwd, admin.State, admin.Id);
                     if (result > 0)
                     {
                         Response.Write("<script>alert('修改成功！！！')</script>");
                         Response.Redirect("userList.aspx");
                     }

                 }
                 else
                 {
                     Response.Write("<script>alert('两次密码不一致！！！')</script>");
                 }
             }
            

        }
    }
}