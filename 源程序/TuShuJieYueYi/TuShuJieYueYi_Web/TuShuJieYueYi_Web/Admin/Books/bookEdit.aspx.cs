using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;

namespace TuShuJieYueYi_Web.Admin.Books
{
    public partial class bookEdit : System.Web.UI.Page
    {
        //input框中存取图片的路径
        public string Imgurl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //列表页传输过来的id
            int id = Convert.ToInt32(Request["id"]);
            BookBll bll = new BookBll();
            //从数据库获取实体
            Book model = bll.GetBookModel(id);
            //首次加载，设置视图控件的值
            if (!IsPostBack)
            {
                txtBookName.Value = model.Bookname;
                txtAuthor.Value = model.Author;
                txtPublish.Value = model.Publishing_hose;
                txtYear.Value = model.YearString;
                txtPrice.Value = model.Price.ToString();
                txtDecorate.Value = model.Decorate;
                txtISBN.Value = model.Number;
                txtAuthor_introduce.Value = model.Author_introduce;
                txtBook_introduce.InnerText = model.Book_introduce;
                //图片路径获取，并赋值给input
                Imgurl = model.Image;
                txtCatalog.Value = model.Catalogs;
            }
            else
            {
                //分别设置model实体属性的值
                model.Id = id;
                model.Bookname = txtBookName.Value;
                model.Author = txtAuthor.Value;
                model.Publishing_hose = txtPublish.Value;
                model.Publishing_year = Convert.ToDateTime(txtYear.Value);
                model.Price = Convert.ToDecimal(txtPrice.Value);
                model.Decorate = txtDecorate.Value;
                model.Number = txtISBN.Value;
                model.Author_introduce = txtAuthor_introduce.Value;
                model.Book_introduce = txtBook_introduce.InnerText;
                model.Image = Request["inputimg"];
                model.Catalogs = txtCatalog.Value;
                //执行修改
                int result = bll.BookUpdate(model);
                if (result > 0)
                {
                    Response.Write("<script>alert('修改成功！');window.location.href='bookList.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改失败！')</script>");
                }
            }
        }
    }
}