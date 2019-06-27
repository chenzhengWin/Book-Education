using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using Model;
using BLL;

namespace TuShuJieYueYi_Web
{
    /// <summary>
    /// Loading 的摘要说明
    /// </summary>
    public class Loading : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //context.Response.Write("Hello World");
            string action = context.Request["action"];
         
            if (action == "1")
            {
                NavBLL bll = new NavBLL();
                DataTable dt= bll.NavQuery();
                List<Nnav> list = new List<Nnav>();
                foreach (DataRow dr in dt.Rows)
                {
                    Nnav p1 = new Nnav();
                    p1.Id = Convert.ToInt32(dr["Id"]);
                    p1.Name = dr["name"].ToString();
                    list.Add(p1);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string str = js.Serialize(list);
                context.Response.Write(str);
            }
            if (action == "2")
            {
                List<Eenter> list = new List<Eenter>();
                EntranceBll bll = new EntranceBll();
                DataTable dt = bll.ShowEnter(1);
                foreach (DataRow dr in dt.Rows)
                {
                    Eenter e1 = new Eenter();
                    e1.Id = Convert.ToInt32(dr["Id"]);
                    e1.Cname = dr["Cname"].ToString();
                    e1.Ename = dr["Ename"].ToString();
                    e1.News = dr["news"].ToString();
                    list.Add(e1);
                   
                }
              JavaScriptSerializer js = new JavaScriptSerializer();
              string str = js.Serialize(list);
              context.Response.Write(str);
            }
            if (action == "3")
            {
                List<Eenter> list = new List<Eenter>();
                EntranceBll bll = new EntranceBll();
                DataTable dt = bll.ShowEnter(2);
                foreach (DataRow dr in dt.Rows)
                {
                    Eenter e2 = new Eenter();
                    e2.Id = Convert.ToInt32(dr["Id"]);
                    e2.Cname = dr["Cname"].ToString();
                    e2.Ename = dr["Ename"].ToString();
                    e2.News = dr["news"].ToString();
                    list.Add(e2);

                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string str = js.Serialize(list);
                context.Response.Write(str);
            }
            if (action == "4")
            {
                
                BookBll b1=new BookBll();
                List<Book> list = b1.GetModelList("kindId=7");
                JavaScriptSerializer js = new JavaScriptSerializer();
                string str = js.Serialize(list);
                context.Response.Write(str);
            }
            if (action == "5")
            {
                List<Notice> list = new List<Notice>();
                NoticeBll bll = new NoticeBll();
                DataTable dt = bll.showNotice();
                if (dt.Rows.Count > 0)
                {
                    for (int i = dt.Rows.Count - 1; i > dt.Rows.Count - 11; i--)
                    {

                        Notice n1 = new Notice();
                        n1.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                        n1.Title = dt.Rows[i]["title"].ToString();
                        n1.News = dt.Rows[i]["news"].ToString();
                        n1.Time = dt.Rows[i]["time"].ToString();
                        list.Add(n1); 
                        
                    }

                }
               
                JavaScriptSerializer js = new JavaScriptSerializer();
                string str = js.Serialize(list);
                context.Response.Write(str);
            }
           
        }

             
        public class Nnav
        {
            public int Id{get;set;}
            public string Name { get; set;}


        }
        public class Eenter
        {
            public int Id { get; set; }
            public string Cname { get; set; }
            public string Ename { get; set; }
            public string News { get; set; }


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