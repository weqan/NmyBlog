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
    public class BlogController : Controller
    {
        BlogDAL bodal=new BlogDAL();
        CategoryDAL cadal=new CategoryDAL();
        public IActionResult Index()
        {
            List<Blog> list = bodal.GetList("");
            return View(list);
        }

        public IActionResult Add(int? id)
        {
            ViewBag.calist = cadal.GetList("");
            Blog bo=new Blog();
            if (id!=null)
            {
                bo = bodal.GetModel(id.Value);
            }
            return View(bo);
        }

        [HttpPost]
        public IActionResult Add(Blog bo)
        {
            Category ca = cadal.GetModelByBh(bo.CaBh);
            if (ca!=null)
            {
                bo.CaName = ca.CaName;
            }
            if (bo.Id==0)
            {
                //新增
                bodal.Insert(bo);
            }
            else
            {
                //修改
                bodal.Update(bo);
            }

            return Redirect("/Adnn1n/Blog/Index");
        }

        public IActionResult Del(int id)
        {
            bodal.Delete(id);
            return Redirect("/Adnn1n/Blog/Index");
        }
    }
}