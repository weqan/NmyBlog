using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NmyBlog.DAL;
using NmyBlog.Model;

namespace NmyBlog.Web.Areas.Adnn1n.Controllers
{
    public class CategoryController : Controller
    {
        CategoryDAL cadal = new CategoryDAL();

        [Area("Adnn1n")]
        public IActionResult Index()
        {

            List<Category> list = cadal.GetList("");
            return View(list);
        }

        //public IActionResult Add(int? id)
        //{
        //    Category ca = new Category();
        //    if (id != null)
        //    {
        //        ca = cadal.GetModel(id.Value);
        //    }

        //    return View(ca);
        //}

        //[HttpPost]
        //public IActionResult Add(Blog bo)
        //{
        //    Category ca = cadal.GetModelByBh(bo.CaBh);
        //    if (ca != null)
        //    {
        //        bo.CaName = ca.CaName;
        //    }

        //    if (bo.Id == 0)
        //    {
        //        //新增
        //        bodal.Insert(bo);
        //    }
        //    else
        //    {
        //        //修改
        //        bodal.Update(bo);
        //    }

        //    return Redirect("/Adnn1n/Blog/Index");
        //}

        //public IActionResult Del(int id)
        //{
        //    bodal.Delete(id);
        //    return Redirect("/Adnn1n/Blog/Index");
        //}
    }
}
