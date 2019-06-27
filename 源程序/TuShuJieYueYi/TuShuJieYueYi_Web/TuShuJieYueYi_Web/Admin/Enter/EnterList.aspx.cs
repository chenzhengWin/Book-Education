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
    public partial class EnterList : System.Web.UI.Page
    {
        EntranceBll bll = new EntranceBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        //数据绑定
        public void Bind()
        {
            DataTable dt = bll.ShowEnter();
            repList.DataSource = dt;
            repList.DataBind();
        }

        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string  rult = e.CommandName; 
            int id = Convert.ToInt32(e.CommandArgument);
            if(rult=="Edit")
            {
                 Response.Redirect("EnterEdit.aspx?Id="+id+"");
            }
           
            
        }

    }
}