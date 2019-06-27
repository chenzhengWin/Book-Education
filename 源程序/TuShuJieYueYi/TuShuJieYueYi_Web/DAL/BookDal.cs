using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class BookDal
    {

        //验证书名是否存在
        public int BookExist(string bookname)
        {
            string sql = "select * from Book where bookname=@bookname";
            SqlParameter sp = new SqlParameter("@bookname",bookname);
            int result =Convert.ToInt32( SqlHelper.getsingledata(sql,sp));

            return result;
        }

        //验证图书编号是否存在
        public int NumExist(int number)
        {
            string sql = "select * from Book where number=@number";
            SqlParameter sp = new SqlParameter("@number",number);
            int result = Convert.ToInt32(SqlHelper.getsingledata(sql, sp));

            return result;
        }



        /// <summary>
        /// 添加图书信息
        /// </summary>
        /// <param name="model">图书实体</param>
        /// <returns>受影响的行数</returns>
        public int BookAdd(Book model)
        {
            string sql = @"INSERT INTO [Library].[dbo].[Book] (author, catalogs, bookname, publishing_house, publishing_year, price, decorate, number, author_introduce, book_introduce, img, kindId)
                            VALUES(@author, @catalogs, @bookname, @publishing_house, @publishing_year, @price, @decorate, @number, @author_introduce, @book_introduce, @img, @kindId)";
            SqlParameter[] sps = { 
                                 new SqlParameter("@author",model.Author),
                                 new SqlParameter("@catalogs",model.Catalogs),
                                 new SqlParameter("@bookname",model.Bookname),
                                 new SqlParameter("@publishing_house",model.Publishing_hose),
                                 new SqlParameter("@publishing_year",model.Publishing_year),
                                 new SqlParameter("@price",model.Price),
                                 new SqlParameter("@decorate",model.Decorate),
                                 new SqlParameter("@number",model.Number),
                                 new SqlParameter("@author_introduce",model.Author_introduce),
                                 new SqlParameter("@book_introduce",model.Book_introduce),
                                 new SqlParameter("@img",model.Image),
                                 new SqlParameter("@kindId",model.KindId)
                            };
            int result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(sql, sps));
            return result;
        }
        /// <summary>
        /// 删除书籍信息
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>受影响的行数</returns>
        public int BookDelete(int id)
        {
            string sql = "delete Book where id=@id";
            SqlParameter sp = new SqlParameter("@id", id);
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery(sql, sp));
        }
        /// <summary>
        /// 修改书籍信息
        /// </summary>
        /// <param name="model">图书实体</param>
        /// <returns>受影响的行数</returns>
        public int BookUpdate(Book model)
        {
            string sql = @"update Book set author=@author,catalogs=@catalogs, bookname=@bookname, publishing_house=@publishing_house, publishing_year=@publishing_year, price=@price,
            decorate=@decorate, number=@number, author_introduce=@author_introduce, book_introduce=@book_introduce, img=@img where Id=@id";
            SqlParameter[] sps = { 
                                 new SqlParameter("@author",model.Author),
                                 new SqlParameter("@catalogs",model.Catalogs),
                                 new SqlParameter("@bookname",model.Bookname),
                                 new SqlParameter("@publishing_house",model.Publishing_hose),
                                 new SqlParameter("@publishing_year",model.Publishing_year),
                                 new SqlParameter("@price",model.Price),
                                 new SqlParameter("@decorate",model.Decorate),
                                 new SqlParameter("@number",model.Number),
                                 new SqlParameter("@author_introduce",model.Author_introduce),
                                 new SqlParameter("@book_introduce",model.Book_introduce),
                                 new SqlParameter("@img",model.Image),
                                 new SqlParameter("@id",model.Id)
                            };
            int result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(sql, sps));
            return result;
        }
        /// <summary>
        /// 获取所有图书表
        /// </summary>
        /// <returns>表</returns>
        public DataTable GetBookTable()
        {
            string sql = "select * from Book";
            DataTable dt = SqlHelper.ExeDataTable(sql);
            return dt;
        }
        /// <summary>
        /// 根据Id查询该图书信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public Book GetBookModel(int id)
        {
            Book model = new Book();            
            string sql = "select * from Book where Id=@id";
            SqlParameter[] sps = {
                                      new SqlParameter("@id",id)
                                  };
            DataTable dt = SqlHelper.ExeDataTable(sql, sps);
            //获取的行数>0
            if(dt.Rows.Count>0)
            {
                DataRow dr = dt.Rows[0];
                if (!dr.IsNull("Id"))
                {
                    model.Id = Convert.ToInt32(dr["Id"]);
                }
                if (!dr.IsNull("author"))
                {
                    model.Author = Convert.ToString(dr["author"]);
                }
                if (!dr.IsNull("catalogs"))
                {
                    model.Catalogs = Convert.ToString(dr["catalogs"]);
                }
                if (!dr.IsNull("bookname"))
                {
                    model.Bookname = Convert.ToString(dr["bookname"]);
                }
                if (!dr.IsNull("publishing_house"))
                {
                    model.Publishing_hose = Convert.ToString(dr["publishing_house"]);
                }
                if (!dr.IsNull("publishing_year"))
                {
                    model.Publishing_year = Convert.ToDateTime(dr["publishing_year"]);
                }
                if (!dr.IsNull("price"))
                {
                    model.Price = Convert.ToDecimal(dr["price"]);
                }

                if (!dr.IsNull("decorate"))
                {
                    model.Decorate = Convert.ToString(dr["decorate"]);
                }
                if (!dr.IsNull("number"))
                {
                    model.Number = Convert.ToString(dr["number"]);
                }
                if (!dr.IsNull("author_introduce"))
                {
                    model.Author_introduce = Convert.ToString(dr["author_introduce"]);
                }
                if (!dr.IsNull("book_introduce"))
                {
                    model.Book_introduce = Convert.ToString(dr["book_introduce"]);
                }
                if (!dr.IsNull("img"))
                {
                    model.Image = Convert.ToString(dr["img"]);
                }
                if (!dr.IsNull("kindId"))
                {
                    model.KindId = Convert.ToInt32(dr["KindId"]);
                }            
            }
            return model;
        }
        /// <summary>
        /// 查询获取多个图书信息
        /// </summary>
        /// <param name="strWhere">sql语句中的where条件</param>
        /// <returns>图书实体对象集合</returns>
        public List<Book> GetModelList(string strWhere, string order = "kindId", bool asc = true)//升序
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from Book ");

            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(" where " + strWhere);
            }
            if (asc)
            {
                builder.Append(" order by  " + order);
            }
            else
            {
                builder.Append(" order by  " + order + " desc");
            }

            DataTable dt = SqlHelper.ExeDataTable(builder.ToString());
            List<Book> list = new List<Book>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Book model = DataRowToModel(dr);
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 关键词查询获取图书信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns>图书表</returns>
        public DataTable GetGroupTable(string key)
        {
            string sql = "select * from Book where bookname like '%"+ key +"%'";
            DataTable dt = SqlHelper.ExeDataTable(sql);
            return dt;
        }
        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from Book";
            int result = Convert.ToInt32(SqlHelper.getsingledata(sql));
            return result;
        }
        /// <summary>
        /// 转换实体方法
        /// </summary>
        /// <returns>图书实体</returns>
        public Book DataRowToModel(DataRow dr)
        {
            Book model = new Book();
            if (!dr.IsNull("Id"))
            {
                model.Id = Convert.ToInt32(dr["Id"]);
            }
            if (!dr.IsNull("author"))
            {
                model.Author = Convert.ToString(dr["author"]);
            }
            if (!dr.IsNull("catalogs"))
            {
                model.Catalogs = Convert.ToString(dr["catalogs"]);
            }
            if (!dr.IsNull("bookname"))
            {
                model.Bookname = Convert.ToString(dr["bookname"]);
            }
            if (!dr.IsNull("publishing_house"))
            {
                model.Publishing_hose = Convert.ToString(dr["publishing_house"]);
            }
            if (!dr.IsNull("publishing_year"))
            {
                model.Publishing_year = Convert.ToDateTime(dr["publishing_year"]);
            }
            if (!dr.IsNull("price"))
            {
                model.Price = Convert.ToDecimal(dr["price"]);
            }

            if (!dr.IsNull("decorate"))
            {
                model.Decorate = Convert.ToString(dr["decorate"]);
            }
            if (!dr.IsNull("number"))
            {
                model.Number = Convert.ToString(dr["number"]);
            }
            if (!dr.IsNull("author_introduce"))
            {
                model.Author_introduce = Convert.ToString(dr["author_introduce"]);
            }
            if (!dr.IsNull("book_introduce"))
            {
                model.Book_introduce = Convert.ToString(dr["book_introduce"]);
            }
            if (!dr.IsNull("img"))
            {
                model.Image = Convert.ToString(dr["img"]);
            }
            if (!dr.IsNull("kindId"))
            {
                model.KindId = Convert.ToInt32(dr["KindId"]);
            }
            return model;
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from Book T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return SqlHelper.Query(strSql.ToString());
        }

    }
}
