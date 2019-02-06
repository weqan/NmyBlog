using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NmyBlog.DAL;
using NmyBlog.Model;

namespace NmyBlog.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            string str = "";
            CategoryDAL cd=new CategoryDAL();
            str = "新增分类返回的ID值：" + cd.Insert(new Category(){CaName = "newca"})+"<hr />";

            bool bl = cd.Delete(8);
            str += "删除ID=8的结果为" + bl;

            Category ca = cd.GetModel(7);
            if (ca!=null)
            {
                ca.CaName = "abc";
                bool bl2 = cd.Update(ca);
                str += "ID=7的数据的CaName修改结果为:" + bl2;
            }

            List<Category> list = cd.GetList("Bh = 222");
            foreach (var model in list)
            {
                str += $"<div>分类ID:{model.Id}分类名称：{model.CaName}</div>";
            }


            return Content(str);
        }
    }
}