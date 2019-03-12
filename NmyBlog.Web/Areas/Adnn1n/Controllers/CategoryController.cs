using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NmyBlog.DAL;
using NmyBlog.Model;

namespace NmyBlog.Web.Areas.Adnn1n.Controllers
{
    [Area("Adnn1n")]
    public class CategoryController : BaseController
    {
        CategoryDAL cadal = new CategoryDAL();

        public IActionResult Index()
        {

            List<Category> list = cadal.GetList("");
            return View(list);
        }

        public IActionResult Add(int? id)
        {
            Category ca = new Category();
            if (id != null)
            {
                ca = cadal.GetModel(id.Value);
            }

            return View(ca);
        }

        [HttpPost]
        public IActionResult Add(Category ca)
        {
            if (ca.Id == 0)
            {
                //新增
                cadal.Insert(ca);
            }
            else
            {
                //修改
                cadal.Update(ca);
            }

            return Redirect("/Adnn1n/Category");
        }

        public IActionResult Del(int id)
        {
            cadal.Delete(id);
            return Redirect("/Adnn1n/Category");
        }
    }
}
