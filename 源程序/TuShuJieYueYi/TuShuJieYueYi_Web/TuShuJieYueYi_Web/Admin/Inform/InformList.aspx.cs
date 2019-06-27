using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Text;
using DAL;


namespace TuShuJieYueYi_Web.Admin.Inform
{
    
    public partial class InformList : System.Web.UI.Page
    {
        NoticeBll bll = new NoticeBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                BindPager();
            }
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        public void Bind()
        {
            DataTable dt = bll.showNotice();
            repList.DataSource = dt;
            repList.DataBind();
        }
        /// <summary>
        /// repeater的操作项的事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var rult = e.CommandName;
            int id =Convert.ToInt32( e.CommandArgument);
            if (rult == "Del")
            {
                int n = bll.DelNotice(id);
                if(n>0)
                {
                    Response.Write("<script>alert('删除成功！');window.location.href='InformList.aspx'</script>"); 
                }
            }
            else
            {
                Response.Redirect("InformEdit.aspx?Id=" + id + "");
            }
        }
        public void BindPager()
        {
            string sql = "SELECT TOP 1000 [Id] ,[title],[news] ,[time] FROM [Library].[dbo].[Notice]";
           //获取查询得到的总条数
   
            this.pager.RecordCount = bll.showNoticeCount();
            int pageIndex = this.pager.CurrentPageIndex - 1;//获取当前条数
            int pageSize = this.pager.PageSize = 2;//设置每一页显示多少条
            repList.DataSource = DAL.SqlHelper.GetCurrentPage(sql, pageIndex,pageSize);
            repList.DataBind();

        }
        protected void pager_PageChanged(object sender, EventArgs e)
        {
           BindPager();
         }

    }
}