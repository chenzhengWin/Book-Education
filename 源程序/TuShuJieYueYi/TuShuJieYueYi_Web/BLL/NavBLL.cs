using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class NavBLL
    {
        NavDAL dal = new NavDAL();
        public DataTable NavQuery()
        {
            return dal.NavQuery();
        }
        public Navigation NavQuery(int id)
        {
            return dal.NavQuery(id);
        }
        public int NavEdit(string name,string url, int id)
        {
            return dal.NavEdit(name,url,id);
        }
        public int NavAdd(string name, string url)
        {
            return dal.NavAdd(name,url);
        }
    }
}
