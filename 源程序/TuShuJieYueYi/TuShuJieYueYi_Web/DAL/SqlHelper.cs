using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace DAL
{
    public class SqlHelper
    {
        //首先创建连接字符串
        public static string constr = "server=local;database=Library;integrated security=true";

        //查询操作 获取首行首列
        public static object getsingledata(string sql, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(constr))//放在using中 会自动关闭连接对象
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();


                }
            }
        }
        //增删改操作  返回受影响的行数
        public static int ExecuteNonQuery(string sql, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();

                }
            }
        }

        //查询操作 返回一个datareader对象 连接式获取多条数据
        public static SqlDataReader DataReader(string sql, params SqlParameter[] pars)
        {


            SqlConnection conn = new SqlConnection(constr);//因为要一直连接获取数据 所以不能放using中

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (pars != null)
                {
                    cmd.Parameters.AddRange(pars);
                }
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //当关闭DataReader对象时，会自动的将关联的连接对象关闭

            }

        }


        //断开式获取多条数据 
        public static DataTable ExeDataTable(string sql, params SqlParameter[] pars)
        {

            SqlDataAdapter sda = new SqlDataAdapter(sql, constr);
            if (pars != null)
            {
                sda.SelectCommand.Parameters.AddRange(pars);
            }
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;


        }

        //公共分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="stringSql">需要查询的sql语句</param>
        /// <param name="pageIndex">起始页</param>
        /// <param name="pageSize">每一页显示多少条数据</param>
        /// <returns></returns>
        public static DataSet GetCurrentPage(string stringSql,int pageIndex,int pageSize)
        {
            //打开数据库连接
            using(SqlConnection conn=new SqlConnection(constr))
            {
                //设置每一次页面应该从第几条数据进行显示
                int pages = pageIndex * pageSize;
                //打开数据库连接  执行sql语句进行查询
                SqlCommand cmd = new SqlCommand(stringSql, conn);
                //查询得到的内容填充到dt中
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt=new DataTable();
                sda.Fill(pages,pageSize,dt);
                //关闭数据库连接
                conn.Close();
                //声明dataset数据集 用来获取数据库列表信息
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                return ds;

            }

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
    }
}
//总结：也就是说不管用哪种方式执行sql语句都是要用sqlCommand对象去执行一定的sql语句
//然后执行完了之后  可以用不同的方式去读取 你可以一行一行的读取  也可以返回首行首列
//而 SqlDataAdapter就比较厉害了 他封 装了连接对象、命令对象和sqlDataReader对象