using System;
using System.Collections.Generic;
using System.Text;

namespace NmyBlog.Model
{
    /// <summary>
    ///  分类表
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string CaName { get; set; }
        public string Bh { get; set; }
        public string Pbh { get; set; }
        public string Remark { get; set; }
    }
}
