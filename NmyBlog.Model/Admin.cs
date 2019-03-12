using System;
using System.Collections.Generic;
using System.Text;

namespace NmyBlog.Model
{
    /// <summary>
    /// 管理员表
    /// </summary>
    public class Admin
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Remark { get; set; }
    }
}
