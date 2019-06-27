using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class NoticeBll
    {
        //添加
        private NoticeDal dal = new NoticeDal();
        public int AddNotice(Notice model)
        {
            return dal.addNotice(model);
        }
        //查询
        public DataTable showNotice()
        {
            return dal.showNotice();
        }
        //修改
        public int EditNotice(int id, string title, string news, DateTime time)
        {
            return dal.EditNotice(id, title, news, time);
        }
        //查询要修改的数据
        public DataTable QueryNotice(int id)
        {
            return dal.QueryNotice(id);
        }
        //查询总记录数
        public int showNoticeCount()
        {

            return dal.showNoticeCount();

        }
        //搜索关键字查询
        public DataTable seekNotice(string content)
        {
            return dal.seekNotice(content);
        }
        //删除
        public int DelNotice(int id)
        {
            return dal.DelNotice(id);
        }

        public object Getlist(string p)
        {
            throw new NotImplementedException();
        }
    }
}
