using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TuShuJieYueYi_Web.Admin.Enter
{
    public partial class EnterAdd : System.Web.UI.Page
    {
        public string Cname { get; set; }
        public string Ename { get; set; }
        public string news { get; set; }
        public string type1 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                EntranceBll bll = new EntranceBll();
                Cname = Request["cname"];
                Ename = Request["ename"];
                news = Request["news"];
                type1 = Request["type1"];

                if (Cname != "" && Ename != "" && news != "" && type1 != "")
                {
                    Entrance model = new Entrance();
                    model.Cname = Cname;
                    model.Ename = Ename;
                    model.News = news;
                    model.Type = type1;
                    DataTable dt = bll.ShowEnter();
                    foreach (DataRow item in dt.Rows)
                    {
                        if (item["Cname"].ToString() == Cname)
                        {
                            Response.Write("<script>alert('中文名不能重复！！！');</script>");
                            Cname = "";
                            return;
                        }
                        if (item["Ename"].ToString() == Cname)
                        {
                            Response.Write("<script>alert('英文名不能重复！！！');</script>");
                            Ename = "";
                            return;
                        }
                        if (item["news"].ToString() == news)
                        {
                            Response.Write("<script>alert('内容不能重复！！！');</script>");
                            news = "";
                            return;
                        }
                    }
                    int result = bll.AddEnter(model);
                    if (result > 0)
                    {
                        Response.Write("<script>alert('添加成功！')window.location.href='EnterList.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('名字或内容不能为空！！！');</script>");
                }

            }
        }
    }
}