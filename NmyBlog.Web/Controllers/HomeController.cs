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
            List<Blog> list = bodal.GetTopList(3, " sort = 0 ORDER BY createdate DESC");

            ViewBag.xhlist = bodal.GetTopRanList(4, "");

            ViewBag.bomodel = bodal.GetTopList(2, " sort = 0 ORDER BY createdate DESC");

            ViewBag.calist = cadal.GetTopList(4, " pbh = 0 ORDER BY caname");

           //DateTime time1 = DateTime.Today;
            //DateTime time2 = new DateTime(2019 / 1 / 2);
            //TimeSpan ts = time1 - time2;
            //string timespan = (time1 - time2).ToString();

            //ViewBag.rundays = timespan;
            ViewBag.blogcounts = bodal.BlogCounts();

            return View(list);
        }

    }
}
