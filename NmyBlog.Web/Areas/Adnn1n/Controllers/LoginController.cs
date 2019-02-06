using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NmyBlog.Web.Areas.Adnn1n.Controllers
{
    [Area("Adnn1n")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}