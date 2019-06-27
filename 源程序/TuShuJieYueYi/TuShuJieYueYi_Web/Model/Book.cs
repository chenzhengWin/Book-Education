using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //图书
    public class Book
    {
        public int Id { get; set; }
        //作者
        public string Author { get; set; }
        //目录
        public string Catalogs { get; set; }
        //书名
        public string Bookname { get; set; }
        //出版社
        public string Publishing_hose { get; set; }
        //出版时间
        public DateTime Publishing_year { get; set; }
        //价格
        public decimal Price { get; set; }
        //装饰
        public string Decorate { get; set; }
        //编号
        public string Number { get; set; }
        //作者简介
        public string Author_introduce { get; set; }
        //书名简介
        public string Book_introduce { get; set; }
        //图书图片
        public string Image { get; set; }
        //图书分类
        public int KindId { get; set; }
        //日期格式，只显示年月日
        public string YearString
        {
            get { return Publishing_year.ToLongDateString(); }           
        }
    }
}
