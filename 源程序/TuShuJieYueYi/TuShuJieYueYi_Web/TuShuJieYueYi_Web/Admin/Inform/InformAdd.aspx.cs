using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data;

namespace TuShuJieYueYi_Web.Admin.Inform
{
    public partial class InformAdd : System.Web.UI.Page
    {
        public string title { get; set; }
        public string news { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NoticeBll bll = new NoticeBll();
                title = Request["navname"];
                news = Request["navnews"];
                if (title != "" && news != "")
                {
                    DataTable dt = bll.showNotice();
                    foreach (DataRow item in dt.Rows)
                    {
                        if (item["title"].ToString() == title)
                        {
                            Response.Write("<script>alert('通知标题不能重复！！！');</script>");
                            title = "";
                            return;
                        }
                    }
                    Notice model = new Notice();
                    model.Title = title;
                    model.News = news;
                    model.Time = Convert.ToString(DateTime.Now);
                    int result = bll.AddNotice(model);
                    if (result > 0)
                    {
                        Response.Write("<script>alert('添加成功！')window.location.href='InformList.aspx'</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('通知标题不能为空！！！');</script>");
                }

            }
        }
    }
}