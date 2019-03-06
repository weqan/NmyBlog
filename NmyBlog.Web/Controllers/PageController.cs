using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NmyBlog.DAL;
using NmyBlog.Model;

namespace NmyBlog.Web.Controllers
{
    public class PageController : Controller
    {
        BlogDAL bodal = new BlogDAL();
        CategoryDAL cadal=new CategoryDAL();
        public IActionResult Index(int id)
        {
            Blog blog = bodal.GetModel(id);
            ViewBag.bqlist = cadal.GetTopList(4, " pbh = 0 ORDER BY caname");

            ViewBag.tjlist = bodal.GetTopList(3, " sort = 0 ORDER BY visitnum DESC");

            ViewBag.zxlist = bodal.GetTopList(4, " sort = 0 ORDER BY createdate DESC");

            return View(blog);
        }
    }
}