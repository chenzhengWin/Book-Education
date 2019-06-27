using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;

namespace TuShuJieYueYi_Web.Admin.Inform
{
    public partial class InformEdit : System.Web.UI.Page
    {
        NoticeBll bll = new NoticeBll();
        public string title { get; set; }
        public string news { get; set; }
        public DateTime time { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["Id"]);
            if (!IsPostBack)
            {
                Notice model = new Notice();
                DataTable dt = bll.QueryNotice(id);
                DataRow dr = dt.Rows[0];
                if (dt.Rows.Count > 0)
                {
                    title = dr["title"].ToString();
                    news = dr["news"].ToString();
                    time = Convert.ToDateTime(dr["time"]);
                }
            }
            else
            {
                title = Request["navtitle"];
                news = Request["navnews"];
                time = Convert.ToDateTime(Request["navtime"]);
                if (title != "" && news != "")
                {
                    DataTable dt = bll.showNotice();
                    foreach (DataRow item in dt.Rows)
                    {
                        if (item["title"].ToString() == title)
                        {
                            Response.Write("<script>alert('通知标题不能重复！！！');</script>");
                            return;
                        }
                        if (item["news"].ToString() == news)
                        {
                            Response.Write("<script>alert('通知内容不能重复！！！');</script>");
                            return;
                        }
                    }
                    int result = bll.EditNotice(id, title, news, time);
                    if (result > 0)
                    {
                        Response.Write("<script>alert('修改成功！');window.location.href='InformList.aspx'</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('通知标题或内容不能为空！！！');</script>");
                }

            }
        }
    }
}