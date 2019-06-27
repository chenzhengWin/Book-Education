using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace TuShuJieYueYi_Web.Admin.Hander
{
    /// <summary>
    /// ajaxTest 的摘要说明
    /// </summary>
    public class ajaxTest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //context.Response.Write("Hello World");
            var action = context.Request.Params["action"];
            switch (action)
            {
                case "isUserName"://如果得到的参数是isUserName，那么我们就去执行用户名是否重复的方法
                    //调用BLL层方法判断用户是否重复
                    AdminBLL bll = new AdminBLL();
                    var name = context.Request.Params["userName"];
                    if(name!="")
                    {
                        DataTable dt= bll.adminsel();
                        foreach (DataRow item in dt.Rows)
                        { 
                            Msg mm = new Msg();
                            if(item["username"].ToString()==name)
                            {
                               
                                mm.Success = true;
                                mm.Message = "用户名重复，请重新输入！";
                                context.Response.Write(new JavaScriptSerializer().Serialize(mm));

                            }          
                        }
                    
                    }
                    break;
                
            }
        }
        public class Msg
        {
            public bool Success { get; set; }
            public string Message { get; set; }


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