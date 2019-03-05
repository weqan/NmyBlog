using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NmyBlog.DAL;
using NmyBlog.Model;
using NmyBlog.Web.Models;

namespace NmyBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        BlogDAL bodal = new BlogDAL();
        CategoryDAL cadal = new CategoryDAL();
        public IActionResult Index()
        {
            List<Blog> list = bodal.GetTopList(3," sort = 0 ORDER BY createdate DESC");

            ViewBag.bolist = bodal.GetTopList(4, " sort = 0 ORDER BY visitnum DESC");

            ViewBag.bomodel = bodal.GetTopList(1, " sort = 0 ORDER BY createdate DESC");

            ViewBag.calist = cadal.GetTopList(4, " pbh = 0 ORDER BY caname");

            return View(list);
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
