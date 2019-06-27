using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace TuShuJieYueYi_Web.Admin.Books
{
    public partial class bookAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                BookBll bll = new BookBll();
                Book model = new Book();
                //如果提交
                if (IsPostBack)
                { 
                    if(txtISBN.Value.ToString()!=""&&txtYear.Value.ToString()!="")
                    { 
                        model.Bookname = txtBookName.Value;
                        model.Author = txtAuthor.Value;
                        model.Publishing_hose = txtPublish.Value;
                        model.Publishing_year = Convert.ToDateTime(txtYear.Value);
                        model.Price = Convert.ToDecimal(txtPrice.Value);
                        model.Decorate = txtDecorate.Value;
                        model.Number = txtISBN.Value;
                        model.Author_introduce = txtAuthor_introduce.Value;
                        model.Book_introduce = txtBook_introduce.Value;
                        model.Image = imgurl.Value;
                        model.Catalogs = txtCatalog.Value;
                        model.KindId = Convert.ToInt32(txtKind.Value);
                        //执行添加方法
                        int result = bll.BookAdd(model);
                        if (result > 0)
                        {
                            Response.Write("<script>alert('添加成功！');window.location.href='bookList.aspx'</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('添加失败！')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('请输入必填项！')</script>");

                    }
                }
          
        }

        protected void txtBookName_ServerChange(object sender, EventArgs e)
        {

        }
    }
}