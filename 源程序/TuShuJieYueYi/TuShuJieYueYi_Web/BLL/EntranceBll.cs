using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;
using BLL;
using System.Data.SqlClient;

namespace BLL
{
    public class EntranceBll
    {
        private EntranceDal dal = new EntranceDal();
        //显示首页进入模块
        public DataTable ShowEnter()
        {
            return dal.ShowEnter();
        }
        //添加数据到数据库
        public int AddEnter(Entrance model)
        {
            return dal.AddEnter(model);
        }

        //显示首页进入模块   根据type查询
        public DataTable ShowEnter(int type)
        {
            DataTable dt = new DataTable();
            string sql = "select * from Entrance where type=@type";
            SqlParameter[] sps = {       
                                      new SqlParameter("@type",type),
                                   };
            dt = SqlHelper.ExeDataTable(sql, sps);
            return dt;
        }



        //修改首页入口内容
        public int EditEnter(int id,string cname,string ename, string news,string type)
        {
            return dal.EditEnter(id,cname,ename,news,type);
        }
        public DataTable QueryEnter(int id)
        {         
            return dal.QueryEnter(id);
        }
    }
}
