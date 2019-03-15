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
    public class AdminController : BaseController
    {
        AdminDAL addal = new AdminDAL();
        public IActionResult Index()
        {
            List<Admin> list = addal.GetList("");
            return View(list);
        }

        public IActionResult Add(int? id)
        {
            ViewBag.adlist = addal.GetList("");
            Admin ad = new Admin();
            if (id != null)
            {
                ad = addal.GetModel(id.Value);

            }
            return View(ad);
        }

        [HttpPost]
        public IActionResult Add(Admin ad)
        {
            if (ad.Id == 0)
            {
                ad.Password = Tool.MD5Hash(ad.Password);
                //新增
                addal.Insert(ad);
            }
            else
            {
                //修改
                addal.Update(ad);
            }

            return Redirect("/Adnn1n/Admin");
        }

        public IActionResult Del(int id)
        {
            addal.Delete(id);
            return Redirect("/Adnn1n/Admin");
        }


    }
}