using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class NavDAL
    {
        public Navigation ToModel(DataRow dr)
        {
            Navigation model = new Navigation();
            if (dr["Id"] != DBNull.Value)
            {
                model.Id = Convert.ToInt32(dr["Id"]);
            }
            if (dr["Name"] != DBNull.Value)
            {
                model.Name = dr["Name"].ToString();
            }
            if (dr["url"] != DBNull.Value)
            {
                model.Url = dr["url"].ToString();
            }
            return model;
        }
        //导航查询
        public DataTable NavQuery()
        {
            string sql = "select * from Navigation";
            DataTable dt = SqlHelper.ExeDataTable(sql);
            return dt;
        }
        public Navigation NavQuery(int id)
        {
            string sql = "select * from Navigation where Id=@id";
            SqlParameter sp = new SqlParameter("@id", id);
            DataTable dt = SqlHelper.ExeDataTable(sql, sp);
            Navigation nav = new Navigation();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                nav = ToModel(dr);
            }

            return nav;
        }
        //导航修改
        public int NavEdit(string name, string url, int id)
        {
            string sql = "UPDATE [Library].[dbo].[Navigation] SET [name] = @name,[url] = @url  WHERE id=@id";
            SqlParameter[] sps ={
                                   new SqlParameter("@name",name),
                                   new SqlParameter("@url",url),
                                   new SqlParameter("@id",id),
                                    
                               };
            int result = SqlHelper.ExecuteNonQuery(sql, sps);
            return result;
        }
        //导航添加
        public int NavAdd(string name, string url)
        {
            string sql = "INSERT INTO [Library].[dbo].[Navigation] ([name]  ,[url]) VALUES (@name ,@url>)";
            SqlParameter[] sps ={
                                   new SqlParameter("@name",name),
                                   new SqlParameter("@url",url),
                                   
                               };
            
            int result = SqlHelper.ExecuteNonQuery(sql, sps);
            return result;
        }

    }
}
