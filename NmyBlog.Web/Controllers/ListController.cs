using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NmyBlog.DAL;
using NmyBlog.Model;

namespace NmyBlog.Web.Controllers
{
    public class ListController : Controller
    {
        BlogDAL bodal = new BlogDAL();
        CategoryDAL cadal = new CategoryDAL();
        public IActionResult Index()
        {
            List<Blog> list = bodal.GetList(" sort = 0 ORDER BY createdate DESC");

            ViewBag.bolist = bodal.GetTopList(4, " sort = 0 ORDER BY visitnum DESC");

            ViewBag.calist = cadal.GetTopList(4, " pbh = 0 ORDER BY caname");

            return View(list);
        }


    }
}