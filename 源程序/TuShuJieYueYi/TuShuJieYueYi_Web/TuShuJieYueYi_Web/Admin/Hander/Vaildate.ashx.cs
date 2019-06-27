using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using BLL;
using Model;
using System.Web.Script.Serialization;


namespace TuShuJieYueYi_Web.Admin.Hander
{
    /// <summary>
    /// Vaildate 的摘要说明
    /// </summary>
    public class Vaildate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //context.Response.Write("Hello World");
            int action =Convert.ToInt32( context.Request["action"]);
            if(action==1)
            {
                string name = context.Request["name"];
                BookBll bll = new BookBll();
                ValidateMsg v1 = new ValidateMsg();
                int result = bll.BookExist(name);
                if(result>0)
                {
                    v1.Success = true;
                    v1.OkMsg = "用户名已存在！！！";
                  
                    
                }
                else
                {
                    v1.Success = false;
                    v1.OkMsg = "输入正确！！！";
                } 
                JavaScriptSerializer js = new JavaScriptSerializer();
                string str = js.Serialize(v1);
                context.Response.Write(str);


            }
            if (action == 2)
            {
                if(context.Request["num"]!="")
                {
                    int name =Convert.ToInt32( context.Request["num"]);
                    BookBll bll = new BookBll();
                    ValidateMsg v1 = new ValidateMsg();
                    int result = bll.NumExist(name);
                    if (result > 0)
                    {
                        v1.Success = true;
                        v1.OkMsg = "图书编号已存在！！！";


                    }
                    else
                    {
                        v1.Success = false;
                        v1.OkMsg = "输入正确！！！";
                    }
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string str = js.Serialize(v1);
                    context.Response.Write(str);
                }
               
            }
        }

        public class ValidateMsg
        {
            public bool Success { get; set; }
            public string OkMsg { get; set; }

        }
        

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}