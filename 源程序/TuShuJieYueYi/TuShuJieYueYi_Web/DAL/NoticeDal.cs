using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DAL;

namespace DAL
{
    public class NoticeDal
    {
        //添加
        public int addNotice(Notice model)
        {
            string sql = "insert Notice values(@title,@news,@time)";
            SqlParameter[] sps = { new SqlParameter("@title", model.Title), new SqlParameter("@news", model.News), new SqlParameter("@time", model.Time) };
            int result = SqlHelper.ExecuteNonQuery(sql, sps);
            return result;
        }
        //查询表
        public DataTable showNotice()
        {
            DataTable dt = new DataTable();
            string sql = "select * from Notice";
            dt = SqlHelper.ExeDataTable(sql);
            return dt;

        }

        //删除
        public int DelNotice(int id)
        {
            string sql = "Delete from Notice where Id=@id";
            SqlParameter sp = new SqlParameter("@id", id);
            int n = SqlHelper.ExecuteNonQuery(sql, sp);
            return n;
        }
        //修改
        public int EditNotice(int id, string title, string news, DateTime time)
        {
            string sql = "Update Notice set title=@title,news=@news,time=@time where Id=@id";
            SqlParameter[] sps ={
                                   new SqlParameter("@id",id),
                                   new SqlParameter("@title",title),
                                   new SqlParameter("@news",news),
                                   new SqlParameter("@time",time)
                               };
            int result = SqlHelper.ExecuteNonQuery(sql, sps);
            return result;
        }
        //查询要修改的数据/查询每条数据的详情
        public DataTable QueryNotice(int id)
        {
            string sql = "select * from Notice where Id=@id";
            SqlParameter[] sps = {
                                      new SqlParameter("@id",id)
                                  };
            DataTable dt = SqlHelper.ExeDataTable(sql, sps);
            return dt;
        }

        //查询总记录数
        public int showNoticeCount()
        {
            string sql = "select Count(*) from Notice";
            int result = Convert.ToInt32(SqlHelper.getsingledata(sql));
            return result;
        }

        //搜索关键字查询
        public DataTable seekNotice(string content)
        {
            DataTable dt = new DataTable();
            string sql = "select * from Notice where title Like" + " '%" + content + "%'";
            dt = SqlHelper.ExeDataTable(sql);
            return dt;
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
                strSql.Append("order by T.House_ID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_House T ");
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
