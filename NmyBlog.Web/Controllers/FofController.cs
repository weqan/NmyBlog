using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NmyBlog.DAL;

namespace NmyBlog.Web.Controllers
{
    public class FofController : Controller
    {
        BlogDAL bodal=new BlogDAL();
        public IActionResult Index()
        {
            ViewBag.bolist = bodal.GetTopRanList(2, "");
            return View();
        }
    }
}