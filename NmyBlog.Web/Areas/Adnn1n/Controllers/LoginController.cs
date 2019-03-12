using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NmyBlog.DAL;
using NmyBlog.Model;

namespace NmyBlog.Web.Areas.Adnn1n.Controllers
{
    [Area("Adnn1n")]
    public class LoginController : Controller
    {
        AdminDAL addal =new AdminDAL();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            username = Tool.GetSafeSQL(username);
            //password = Tool.MD5Hash(password);

            Admin a = addal.Login(username, password);
            if (a == null)
            {
                return Content("<script> alert('NmyLogin Error!'); location.href='/Adnn1n/Login'</script>", "text/html");
            }
            HttpContext.Session.SetInt32("adminid", a.Id);
            HttpContext.Session.SetString("adminusername", a.UserName);
            return Redirect("/Adnn1n/Home");
        }
    }
}