using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Data;
using System.Data.SqlClient;


namespace BLL
{
    public class AdminBLL
    {
        AdminDAL a1 = new AdminDAL();
        //用户登录
        public Adminor Login(string username, string pwd)
        {
            return a1.Login(username, pwd);
        }

        //用户添加
        public int adminadd(string username,string pwd)
        {
            return a1.adminadd(username,pwd);
        }
        //用户修改  修改用户名和密码
        public int adminedit(string username,string pwd,int state,int id)
        {
            return a1.adminedit(username, pwd,state,id);
        }

        //用户删除  
        public int admindel(int id)
        {
            return a1.admindel(id);

        }
        //用户查询
        public DataTable adminsel()
        {
            return a1.adminsel();
        }
        //用户查询  查询总记录数
        public int adminselcount()
        {

            return a1.adminselcount(); 

        }

        //用户查询  按id查询
        public Adminor adminsel(int id)
        {
           
            return a1.adminsel(id);

        }
    }
}
