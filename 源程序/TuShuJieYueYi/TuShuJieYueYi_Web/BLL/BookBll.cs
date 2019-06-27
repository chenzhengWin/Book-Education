using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class BookBll
    {
        BookDal dal = new BookDal();

        //验证书名是否存在
        public int BookExist(string bookname)
        {
            return dal.BookExist(bookname);
        }

        //验证图书编号是否存在
        public int NumExist(int number)
        {
            return dal.NumExist(number);
        }


        /// <summary>
        /// 添加图书信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int BookAdd(Book model)
        {
            return dal.BookAdd(model);
        }
        /// <summary>
        /// 删除图书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int BookDelete(int id)
        {
            return dal.BookDelete(id);
        }
        /// <summary>
        /// 修改书籍信息
        /// </summary>
        /// <param name="model">图书实体</param>
        /// <returns>受影响的行数</returns>
        public int BookUpdate(Book model)
        {
            return dal.BookUpdate(model);
        }
        /// <summary>
        /// 获取图书信息
        /// </summary>
        /// <returns>图书表</returns>
        public DataTable GetBookTable()
        {
            return dal.GetBookTable();
        }
        /// <summary>
        /// 根据图书类别查询获取多个图书信息
        /// </summary>
        /// <param name="strWhere">sql语句中的where条件</param>
        /// <returns>图书实体对象集合</returns>
        public List<Book> GetModelList(string strWhere, string order = "kindId", bool asc = true)//升序
        {
            return dal.GetModelList(strWhere,order,asc);
        }
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book GetBookModel(int id)
        {
            return dal.GetBookModel(id);
        }
        /// <summary>
        /// 关键词查询获取图书信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns>图书表</returns>
        public DataTable GetGroupTable(string key)
        {
            return dal.GetGroupTable(key);
        }
        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            return dal.GetRecordCount();
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}
