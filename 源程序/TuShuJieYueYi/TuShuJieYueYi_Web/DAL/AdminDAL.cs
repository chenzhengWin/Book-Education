using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace DAL
{
    public class AdminDAL
    {
        public Adminor DataRowToModel(DataRow dr)
        {
            Adminor model = new Adminor();
            if (dr["Id"] != DBNull.Value)
            {
                model.Id = Convert.ToInt32(dr["Id"]);
            }
            if (dr["username"] != DBNull.Value)
            {
                model.UserName = dr["username"].ToString();
            }
            if (dr["password"] != DBNull.Value)
            {
                model.PassWord = dr["password"].ToString();
            }
            if (dr["state"] != DBNull.Value)
            {
                model.State = Convert.ToInt32(dr["state"]);
            }
            return model;
        }
        public Adminor Login(string username, string pwd)
        {
            string sql = "select * from Admin where username=@username and password=@pwd";

            SqlParameter[] sps ={
               
                 new SqlParameter("@username",username),
                 new SqlParameter("@pwd",pwd)
                
            };

            DataTable dt = SqlHelper.ExeDataTable(sql,sps);
            
            Adminor model = null;
            //如果查询后的这个结果表里面有值  说明登陆成功
            if (dt.Rows.Count>0)
            {
                DataRow dr = dt.Rows[0];
                model = DataRowToModel(dr);
            }
            return model;
        }

        //用户添加
        public int adminadd(string username, string pwd,int state=1)
        {
            string sql = "INSERT INTO [Library].[dbo].[Admin]([username],[password],[state]) VALUES(@username,@password ,@state)";
             
            SqlParameter[] sps ={
                 new SqlParameter("@username",username),
                 new SqlParameter("@password",pwd),
                 new SqlParameter("@state",state)

            };
            int result = SqlHelper.ExecuteNonQuery(sql,sps);
            return result;
           
        }
        //用户修改  修改用户名和密码
        public int adminedit(string username, string pwd,int state,int id)
        {

            string sql = "UPDATE [Library].[dbo].[Admin] SET [username] =@username,[password] = @password,[state] = @state WHERE [Id]=@Id ";
            SqlParameter[] sps ={
               
                 new SqlParameter("@username",username),
                 new SqlParameter("@password",pwd),
                  new SqlParameter("@state",state),
                 new SqlParameter("@Id",id)

            };
            int result = SqlHelper.ExecuteNonQuery(sql, sps);
            return result;

        }

        //用户删除  
        public int admindel(int id)
        {
            string sql = "delete from Admin where Id=@id";

            SqlParameter[] sps ={
                 new SqlParameter("@Id",id)

            };
            int result = SqlHelper.ExecuteNonQuery(sql, sps);
            return result;

        }
        //用户查询
        public DataTable adminsel()
        {
            string sql = "select * from Admin";
            DataTable dt = SqlHelper.ExeDataTable(sql);
            return dt;

        }
        //用户查询  查询总记录数
        public int adminselcount()
        {
            string sql = "select count(*) from Admin";
            int result=Convert.ToInt32( SqlHelper.getsingledata(sql));
            return result ;

        }
        //用户查询  按id查询
        public Adminor adminsel(int id)
        {
            string sql = "select * from Admin where Id=@id";
            SqlParameter[] sps ={
                         
                 new SqlParameter("@Id",id)
                
            };

            DataTable dt = SqlHelper.ExeDataTable(sql,sps);
            Adminor model = null;
           
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                model = DataRowToModel(dr);
            }
            return model;

        }

        //分页控件
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
                strSql.Append("order by" + orderby);
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
