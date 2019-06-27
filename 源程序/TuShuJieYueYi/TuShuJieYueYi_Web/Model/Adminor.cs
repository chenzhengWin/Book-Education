using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //管理员
    public class Adminor
    {
        public int Id { get; set; }
        //用户名
        public string UserName { get; set; }
        //密码
        public string PassWord { get; set; }
        //状态  0：代表删除   1：代表正常
        public int State { get; set; }
    }
}
