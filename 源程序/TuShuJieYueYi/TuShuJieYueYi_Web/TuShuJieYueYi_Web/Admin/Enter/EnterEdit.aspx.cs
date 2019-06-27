using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;

namespace TuShuJieYueYi_Web.Admin.Enter
{
    public partial class EnterEdit : System.Web.UI.Page
    {
        EntranceBll bll = new EntranceBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["Id"]);
            Entrance model = new Entrance();
            if (!IsPostBack)
            {

                DataTable dt = bll.QueryEnter(id);
                DataRow dr = dt.Rows[0];
                if (dt.Rows.Count > 0)
                {
                    cname.Value = dr["Cname"].ToString();
                    ename.Value = dr["Ename"].ToString();
                    news.Value = dr["news"].ToString();
                    type1.Value = dr["type"].ToString();

                }
            }
            else
            {
                model.Cname = cname.Value; ;
                model.Ename = ename.Value;
                model.News = news.Value;
                model.Type = type1.Value;
                if (model.Cname != "" && model.Ename != "" && model.News != "" && model.Type != "")
                {

                    DataTable dt = bll.QueryEnter(id);
                    foreach (DataRow item in dt.Rows)
                    {
                        if (item["Cname"].ToString() == cname.Value)
                        {
                            Response.Write("<script>alert('中文名不能重复！！！');</script>");
                            return;
                        } 
                        if (item["Ename"].ToString() == ename.Value)
                        {
                            Response.Write("<script>alert('英文名不能重复！！！');</script>");
                            return;
                        }
                        if (item["news"].ToString() == news.Value)
                        {
                            Response.Write("<script>alert('内容不能重复！！！');</script>");
                            return;
                        }
                    }
                    int result = bll.EditEnter(id, model.Cname, model.Ename, model.News, model.Type);
                    if (result > 0)
                    {
                        Response.Write("<script>alert('修改成功！');window.location.href='EnterList.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('名字或内容不能为空！！！');</script>");
                }
            }


        }

        protected void btnOk_ServerClick(object sender, EventArgs e)
        {


        }

    }
}