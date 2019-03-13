using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NmyBlog.Web.Areas.Adnn1n.Controllers
{
    [Area("Adnn1n")]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Session.GetInt32("adminid") == null)
            {
                var con = new ContentResult();


                string r = "Login timeout! Please login again!哈哈哈";

                con.Content = $"<script> alert('{r}');parent.location.href='/adnn1n/login'</script>";
                con.ContentType = "text/html;charset=utf-8";
                filterContext.Result = con;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}