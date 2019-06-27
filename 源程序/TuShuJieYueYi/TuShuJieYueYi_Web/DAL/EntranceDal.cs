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
     public class EntranceDal
    {
        
         //显示首页进入模块
         public DataTable ShowEnter()
         {
             DataTable dt = new DataTable();
             string sql = "select * from Entrance";
             dt = SqlHelper.ExeDataTable(sql);
             return dt;
         }


         //显示首页进入模块   根据type查询
         public DataTable ShowEnter(int type)
         {
             DataTable dt = new DataTable();
             string sql = "select * from Entrance where type=@type";
             SqlParameter[] sps = {       
                                      new SqlParameter("@type",type),
                                   };
             dt = SqlHelper.ExeDataTable(sql,sps);
             return dt;
         }
         //修改首页进入模块
         public int EditEnter(int id,string cname,string ename,string news,string type)
         {
             string sql = "Update Entrance set Cname=@cname,Ename=@ename,news=@news,type=@type where Id=@id";
             SqlParameter[] sps = { 
                                      new SqlParameter("@cname", cname),
                                      new SqlParameter("@ename",ename),
                                      new SqlParameter("@news",news),
                                      new SqlParameter("@type",type),
                                      new SqlParameter("@id",id)
                                  };
             int result = SqlHelper.ExecuteNonQuery(sql, sps);
             return result;

         }
         //添加数据到数据库
         public int AddEnter(Entrance model)
         {
             string sql = "insert Entrance values(@Cname,@Ename,@News,@Type)";
             SqlParameter[] sps = { 
                                      new SqlParameter("@Cname", model.Cname),
                                      new SqlParameter("@Ename", model.Ename),
                                      new SqlParameter("@News", model.News) ,
                                      new SqlParameter("@Type",model.Type)
                                  };
             int result = SqlHelper.ExecuteNonQuery(sql, sps);
             return result;
         }
         //查询要修改的数据
         public DataTable QueryEnter(int id)
         {       
             string sql = "select * from Entrance where Id=@id";
             SqlParameter[] sps = {
                                      new SqlParameter("@id",id)
                                  };
             DataTable dt = SqlHelper.ExeDataTable(sql,sps);        
             return dt;
         }
    }
}
